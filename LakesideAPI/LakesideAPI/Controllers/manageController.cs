using LakesideAPI.Helpers;
using LakesideAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class manageController : ControllerBase
    {
        private readonly AppDbContext _context;

        public manageController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPut("edit-state/{id}")]
        public IActionResult UpdateDatPhongTrangThai(int id, [FromBody] UpdateState request)
        {
            var datPhong = _context.DatPhong.FirstOrDefault(dp => dp.MaDatphong == id);
            if (datPhong == null)
            {
                return NotFound("Không tìm thấy đặt phòng có mã số này.");
            }

            // Cập nhật trạng thái
            datPhong.TrangThai = request.TrangThai;

            // Lưu thay đổi vào cơ sở dữ liệu
            _context.SaveChanges();

            return Ok("Cập nhật trạng thái đặt phòng thành công.");
        }

        //Hiển thị những đơn đặt phòng có cùng trạng thái
        [HttpGet("get-states/{trangThai}")]
        public IActionResult GetDatPhongByTrangThai(string trangThai)
        {
            var datPhongs = _context.DatPhong
                .Where(dp => dp.TrangThai == trangThai)
                .OrderByDescending(dp => dp.MaDatphong) // Sắp xếp theo ID giảm dần
                .ToList();

            if (datPhongs.Count == 0)
            {
                return NotFound("Không có đơn ở trạng thái này");
            }

            return Ok(datPhongs);
        }
    }
}
