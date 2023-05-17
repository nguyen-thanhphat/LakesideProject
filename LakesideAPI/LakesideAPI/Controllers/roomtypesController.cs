using LakesideAPI.Helpers;
using LakesideAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class roomtypesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public roomtypesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("getlist")]
        public async Task<ActionResult<IEnumerable<LoaiPhong>>> GetAll()
        {
            return await _context.LoaiPhong.ToListAsync();
        }

        [HttpGet("getby/{id}")]
        public async Task<ActionResult<LoaiPhong>> GetById(int id)
        {
            var loaiPhong = await _context.LoaiPhong.FindAsync(id);

            if (loaiPhong == null)
            {
                return NotFound();
            }

            return loaiPhong;
        }

        [HttpPost("create")]
        public async Task<ActionResult<LoaiPhong>> Create(LoaiPhong loaiPhong)
        {
            if (ModelState.IsValid)
            {
                _context.LoaiPhong.Add(loaiPhong);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = loaiPhong.MaLoaiPhong }, loaiPhong);
            }
            return BadRequest(ModelState);
        }

        [HttpPut("editby/{id}")]
        public async Task<IActionResult> Update(int id, LoaiPhong loaiPhong)
        {
            if (id != loaiPhong.MaLoaiPhong)
            {
                return BadRequest();
            }

            _context.Entry(loaiPhong).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LoaiPhongExists(id))
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

        private bool LoaiPhongExists(int id)
        {
            return _context.LoaiPhong.Any(e => e.MaLoaiPhong == id);
        }

        [HttpDelete("delby/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var loaiPhong = await _context.LoaiPhong.FindAsync(id);
            if (loaiPhong == null)
            {
                return NotFound();
            }

            _context.LoaiPhong.Remove(loaiPhong);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("upload-image/{id}")]
        public async Task<ActionResult> UploadImage(int id, IFormFile file)
        {
            var loaiPhong = await _context.LoaiPhong.FindAsync(id);

            if (loaiPhong == null)
            {
                return BadRequest("Không tìm thấy loại phòng có mã " + id);
            }

            if (file == null || file.Length == 0)
            {
                return BadRequest("Không có file được chọn hoặc file rỗng.");
            }

            var fileExtension = Path.GetExtension(file.FileName);
            var fileName = Guid.NewGuid().ToString() + fileExtension;
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            loaiPhong.UrlImage = "/uploads/" + fileName;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Upload hình ảnh thành công." });
        }

        [HttpGet("roomby/{idtype}")]
        public IActionResult GetDanhSachPhongTheoMaLoai(int idtype)
        {
            var danhSachPhong = _context.Phong
                .Where(p => p.MaLoaiPhong == idtype)
                .Select(p => new
                {
                    MaPhong = p.MaPhong,
                    TenPhong = p.TenPhong,
                    // Các thuộc tính khác của phòng
                })
                .ToList();

            return Ok(danhSachPhong);
        }

    }
}
