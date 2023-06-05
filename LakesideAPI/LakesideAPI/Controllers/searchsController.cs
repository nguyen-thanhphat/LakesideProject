using LakesideAPI.Helpers;
using LakesideAPI.Models;
using LakesideAPI.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class searchsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public searchsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("room-by/{ngayNhan}/{ngayTra}/{maLoaiPhong}")]
        public async Task<ActionResult<SearchPhong>> GetPhongTrong(DateTime ngayNhan, DateTime ngayTra, int maLoaiPhong)
        {
            // Lấy danh sách các mã phòng đã có trong đặt phòng trong khoảng thời gian
            //var maPhongDaDat = _context.DatPhong
            //    .Where(dp => (dp.NgayNhan >= ngayNhan && dp.NgayNhan <= ngayTra) ||
            //                 (dp.NgayTra >= ngayNhan && dp.NgayTra <= ngayTra) ||
            //                 (dp.NgayNhan <= ngayNhan && dp.NgayTra >= ngayTra))
            //    .Select(dp => dp.MaPhong)
            //    .ToList();

            // Lấy danh sách các mã phòng đã có trong đặt phòng trong khoảng thời gian và có trạng thái là "Đã huỷ" (nếu có)
            var maPhongDaDat = _context.DatPhong
                .Where(dp => ((dp.NgayNhan >= ngayNhan && dp.NgayNhan <= ngayTra) ||
                              (dp.NgayTra >= ngayNhan && dp.NgayTra <= ngayTra) ||
                              (dp.NgayNhan <= ngayNhan && dp.NgayTra >= ngayTra)) ||
                              (dp.TrangThai == "Đã huỷ" || dp.TrangThai == "Đã từ chối"))
                .Select(dp => dp.MaPhong)
                .ToList();

            // Lấy ID của phòng trống đầu tiên có cùng loại và chưa có trong đặt phòng
            var phongChuaCoDatId = _context.Phong
                .Where(p => !maPhongDaDat.Contains(p.MaPhong) && p.MaLoaiPhong == maLoaiPhong)
                .Select(p => p.MaPhong)
                .FirstOrDefault();

            if (phongChuaCoDatId == null)
            {
                return NotFound();
            }

            var phong = await _context.Phong.Include(p => p.LoaiPhong)
                .FirstOrDefaultAsync(p => p.MaPhong == phongChuaCoDatId);

            if (phong == null || phong.LoaiPhong == null)
            {
                return NotFound();
            }

            var loaiPhongDTO = new SearchPhong
            {
                MaPhong = phong.MaPhong,
                TenPhong = phong.TenPhong,
                TenLoaiPhong = phong.LoaiPhong.TenLoaiPhong,
                TienIch = phong.LoaiPhong.TienIch,
                KichCo = phong.LoaiPhong.KichCo,
                GiaPhong = phong.LoaiPhong.GiaPhong,
                UrlImage = phong.LoaiPhong.UrlImage,
                NhinRa = phong.LoaiPhong.NhinRa,
                SucChua = phong.LoaiPhong.SucChua,
                PhuThu = phong.LoaiPhong.PhuThu,
            };

            return loaiPhongDTO;
        }

        [HttpGet("listroom-by/{ngayNhan}/{ngayTra}/{maLoaiPhong}")]
        public async Task<ActionResult<List<SearchPhong>>> GetListPhongTrong(DateTime ngayNhan, DateTime ngayTra, int maLoaiPhong)
        {
            var maPhongDaDat = _context.DatPhong
                .Where(dp => ((dp.NgayNhan >= ngayNhan && dp.NgayNhan <= ngayTra) ||
                              (dp.NgayTra >= ngayNhan && dp.NgayTra <= ngayTra) ||
                              (dp.NgayNhan <= ngayNhan && dp.NgayTra >= ngayTra)) ||
                              (dp.TrangThai == "Đã huỷ" || dp.TrangThai == "Đã từ chối"))
                .Select(dp => dp.MaPhong)
                .ToList();

            var danhSachPhongTrong = await _context.Phong
                .Include(p => p.LoaiPhong)
                .Where(p => !maPhongDaDat.Contains(p.MaPhong) && p.MaLoaiPhong == maLoaiPhong)
                .Select(p => new SearchPhong
                {
                    MaPhong = p.MaPhong,
                    TenPhong = p.TenPhong,
                    TenLoaiPhong = p.LoaiPhong.TenLoaiPhong,
                    TienIch = p.LoaiPhong.TienIch,
                    KichCo = p.LoaiPhong.KichCo,
                    GiaPhong = p.LoaiPhong.GiaPhong,
                    UrlImage = p.LoaiPhong.UrlImage,
                    NhinRa = p.LoaiPhong.NhinRa,
                    SucChua = p.LoaiPhong.SucChua,
                    PhuThu = p.LoaiPhong.PhuThu
                })
                .ToListAsync();

            if (danhSachPhongTrong.Count == 0)
            {
                return NotFound();
            }

            return danhSachPhongTrong;
        }


        [HttpGet("count-available-rooms/{ngayNhan}/{ngayTra}/{maLoaiPhong}")]
        public async Task<ActionResult<int>> CountPhongTrong(DateTime ngayNhan, DateTime ngayTra, int maLoaiPhong)
        {
            // Lấy danh sách các mã phòng đã có trong đặt phòng trong khoảng thời gian và có trạng thái là "Đã huỷ" (nếu có)
            var maPhongDaDat = _context.DatPhong
                .Where(dp => ((dp.NgayNhan >= ngayNhan && dp.NgayNhan <= ngayTra) ||
                              (dp.NgayTra >= ngayNhan && dp.NgayTra <= ngayTra) ||
                              (dp.NgayNhan <= ngayNhan && dp.NgayTra >= ngayTra)) ||
                              (dp.TrangThai == "Đã huỷ" || dp.TrangThai == "Đã từ chối"))
                .Select(dp => dp.MaPhong)
                .ToList();

            var countPhongTrong = await _context.Phong
                .Where(p => !maPhongDaDat.Contains(p.MaPhong) && p.MaLoaiPhong == maLoaiPhong)
                .CountAsync();

            return countPhongTrong;
        }

        [HttpGet("available-rooms/{ngayNhan}/{ngayTra}")]
        public async Task<ActionResult<List<Phong>>> GetPhongChuaDat(DateTime ngayNhan, DateTime ngayTra)
        {
            var maPhongDaDat = _context.DatPhong
                .Where(dp => ((dp.NgayNhan >= ngayNhan && dp.NgayNhan <= ngayTra) ||
                              (dp.NgayTra >= ngayNhan && dp.NgayTra <= ngayTra) ||
                              (dp.NgayNhan <= ngayNhan && dp.NgayTra >= ngayTra)) ||
                              (dp.TrangThai == "Đã huỷ" || dp.TrangThai == "Đã từ chối"))
                .Select(dp => dp.MaPhong)
                .ToList();

            var phongChuaDat = await _context.Phong
                .Where(p => !maPhongDaDat.Contains(p.MaPhong))
                .ToListAsync();

            return phongChuaDat;
        }
    }
}
