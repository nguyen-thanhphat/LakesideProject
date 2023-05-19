using LakesideAPI.Helpers;
using LakesideAPI.Models;
using LakesideAPI.Requests;
using LakesideAPI.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class reservationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public reservationsController(AppDbContext context)
        {
            _context = context;
        }

        #region Đăt phòng khách sạn 
        [HttpPost("create")]
        public IActionResult DatPhong([FromBody] AddDatPhong request)
        {
            // Kiểm tra tính hợp lệ của request và xử lý lỗi nếu cần

            // Tạo một đối tượng DatPhong mới từ request
            var datPhong = new DatPhong
            {
                NgayDat = DateTime.Now,
                NgayNhan = request.NgayNhan,
                NgayTra = request.NgayTra,
                TrangThai = "Đã đặt",
                MaPhong = request.MaPhong,
                TenKhachHang = request.TenKhachHang,
                SoDienThoai = request.SoDienThoai,
                SoDinhDanh = request.SoDinhDanh,
                Email = request.Email
            };

            // Lấy thông tin phòng từ cơ sở dữ liệu
            var phong = _context.Phong
                .Include(p => p.LoaiPhong)
                .FirstOrDefault(p => p.MaPhong == request.MaPhong);


            // Kiểm tra tính hợp lệ của thông tin phòng
            if (phong == null)
            {
                return BadRequest("Không tìm thấy thông tin phòng ");
            }

            // Lưu đối tượng DatPhong vào cơ sở dữ liệu
            _context.DatPhong.Add(datPhong);
            _context.SaveChanges();

            // Tạo một đối tượng Response chứa thông tin đặt phòng, phòng
            var response = new DatPhongResponse
            {
                MaDatPhong = datPhong.MaDatphong,
                NgayDat = datPhong.NgayDat,
                NgayNhan = datPhong.NgayNhan,
                NgayTra = datPhong.NgayTra,
                TrangThai = datPhong.TrangThai,
                TenKhachHang = datPhong.TenKhachHang,
                SoDienThoai = datPhong.SoDienThoai,
                Email = datPhong.Email,
                SoDinhDanh = datPhong.SoDinhDanh,
                Phong = new PhongResponse
                {
                    MaPhong = phong.MaPhong,
                    TenPhong = phong.TenPhong,
                    LoaiPhong = new LoaiPhongResponse
                    {
                        MaLoaiPhong = phong.LoaiPhong.MaLoaiPhong,
                        TenLoaiPhong = phong.LoaiPhong.TenLoaiPhong,
                        TienIch = phong.LoaiPhong.TienIch,
                        NhinRa = phong.LoaiPhong.NhinRa,
                        KichCo = phong.LoaiPhong.KichCo,
                        GiaPhong = phong.LoaiPhong.GiaPhong,
                        SucChua = phong.LoaiPhong.SucChua,
                        PhuThu = phong.LoaiPhong.PhuThu,
                    }
                }
            };

            return Ok(response);
        }
        #endregion

        [HttpGet("getlist")]
        public IActionResult GetListDatPhong()
        {
            var danhSachDatPhong = _context.DatPhong
                .Include(dp => dp.Phong)
                .OrderByDescending(dp => dp.MaDatphong)
                .Select(dp => new
                {
                    TenPhong = dp.Phong != null ? dp.Phong.TenPhong : null,
                    dp.MaDatphong,
                    dp.NgayDat,
                    dp.NgayNhan,
                    dp.NgayTra,
                    dp.TrangThai,
                    dp.TenKhachHang,
                    dp.Email,
                    dp.SoDinhDanh,
                    dp.SoDienThoai
                })
                .ToList();

            return Ok(danhSachDatPhong);
        }
    }   
}
