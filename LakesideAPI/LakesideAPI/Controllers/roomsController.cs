using LakesideAPI.Helpers;
using LakesideAPI.Models;
using LakesideAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roomsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public roomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: List room
        [HttpGet("getlist")]
        public async Task<ActionResult<IEnumerable<Phong>>> GetPhongs()
        {
            return await _context.Phong.ToListAsync();
        }

        // GET: Room by Id
        [HttpGet("getby/{id}")]
        public async Task<ActionResult<Phong>> GetPhong(int id)
        {
            var phong = await _context.Phong.FindAsync(id);

            if (phong == null)
            {
                return NotFound();
            }

            return phong;
        }

        // POST: api/Phongs
        [HttpPost("create")]
        public async Task<ActionResult<Phong>> TaoPhong(int maLoaiPhong)
        {
            // Tìm loại phòng tương ứng với mã loại phòng được cung cấp
            var loaiPhong = await _context.LoaiPhong.FindAsync(maLoaiPhong);
            if (loaiPhong == null)
            {
                return NotFound("Không tìm thấy loại phòng tương ứng");
            }

            // Tạo tên phòng mới
            var lastPhong = await _context.Phong.OrderByDescending(p => p.MaLoaiPhong).FirstOrDefaultAsync();
            int newPhongId = lastPhong != null ? lastPhong.MaPhong + 1 : 1;
            string newPhongName = "Phòng " + newPhongId;

            // Tạo phòng mới và lưu vào cơ sở dữ liệu
            var phong = new Phong
            {
                TenPhong = newPhongName,
                MaLoaiPhong = maLoaiPhong,
                LoaiPhong = loaiPhong
            };
            _context.Phong.Add(phong);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(TaoPhong), new { id = phong.MaPhong }, phong);
        }

        private bool PhongExists(int id)
        {
            return _context.Phong.Any(e => e.MaPhong == id);
        }

        [HttpGet("get-type/{id}")]
        public async Task<ActionResult<SearchPhong>> GetPhongInfo(int id)
        {
            var phong = await _context.Phong.Include(p => p.LoaiPhong)
                .FirstOrDefaultAsync(p => p.MaPhong == id);

            if (phong == null || phong.LoaiPhong == null)
            {
                return NotFound();
            }

            var loaiPhongDTO = new SearchPhong
            {
                TenPhong = phong.TenPhong,
                TenLoaiPhong = phong.LoaiPhong.TenLoaiPhong,
                TienIch = phong.LoaiPhong.TienIch,
                NhinRa = phong.LoaiPhong.NhinRa,
                KichCo = phong.LoaiPhong.KichCo,
                GiaPhong = phong.LoaiPhong.GiaPhong,
                UrlImage = phong.LoaiPhong.UrlImage,
                SucChua = phong.LoaiPhong.SucChua,
                PhuThu = phong.LoaiPhong.PhuThu,
            };

            return loaiPhongDTO;
        }

        //Edit only roomType ForeignKey
        [HttpPut("edittypeby/{id}")]
        public IActionResult SuaLoaiPhong(int id, [FromBody] UpdatePhong request)
        {
            var phong = _context.Phong.FirstOrDefault(p => p.MaPhong == id);

            if (phong == null)
            {
                return NotFound("Không tìm thấy thông tin phòng");
            }

            var loaiPhong = _context.LoaiPhong.FirstOrDefault(lp => lp.MaLoaiPhong == request.MaLoaiPhong);

            if (loaiPhong == null)
            {
                return NotFound("Không tìm thấy thông tin loại phòng");
            }

            phong.MaLoaiPhong = loaiPhong.MaLoaiPhong;

            _context.SaveChanges();

            return Ok("Cập nhật thông tin phòng thành công");
        }

        /* Delete
        // PUT: with body request
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPhong(int id, Phong phong)
        {
            if (id != phong.MaPhong)
            {
                return BadRequest();
            }

            _context.Entry(phong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhongExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Phongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePhong(int id)
        {
            var phong = await _context.Phong.FindAsync(id);
            if (phong == null)
            {
                return NotFound();
            }

            _context.Phong.Remove(phong);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        */
    }
}
