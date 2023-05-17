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
    public class invoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public invoicesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CreateHoaDon([FromBody] AddHoaDon request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Tạo một đối tượng HoaDon mới từ request
            var hoaDon = new HoaDon
            {
                KhachHang = request.KhachHang,
                TenPhong = request.TenPhong,
                NgayDen = request.NgayDen,
                NgayDi = request.NgayDi,
                SoNgayDat = request.SoNgayDat,
                GiaPhong = request.GiaPhong,
                TongTien = request.TongTien,
                MaPhuongThuc = request.MaPhuongThuc,
                MaDatPhong = request.MaDatPhong
            };

            // Lưu hoá đơn vào cơ sở dữ liệu
            _context.HoaDon.Add(hoaDon);
            _context.SaveChanges();

            // Cập nhật trạng thái "Đã thanh toán" trong bảng "DatPhong"
            var datPhong = _context.DatPhong.FirstOrDefault(dp => dp.MaDatphong == hoaDon.MaDatPhong);
            if (datPhong != null)
            {
                datPhong.TrangThai = "Đã thanh toán";
                _context.SaveChanges();
            }

            return Created("", hoaDon);
        }

        [HttpGet]
        public IActionResult GetHoaDons()
        {
            var hoaDons = _context.HoaDon.ToList();
            return Ok(hoaDons);
        }

        [HttpGet("{id}")]
        public IActionResult GetHoaDonById(int id)
        {
            var hoaDon = _context.HoaDon.FirstOrDefault(hd => hd.MaHoaDon == id);

            if (hoaDon == null)
            {
                return NotFound();
            }

            return Ok(hoaDon);
        }
    }
}
