using LakesideAPI.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class statsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public statsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("revenue/{fromDate}/{toDate}")]
        public IActionResult SumRevenue(DateTime fromDate, DateTime toDate)
        {
            var hoaDons = _context.HoaDon
                .Where(h => h.NgayDen >= fromDate && h.NgayDi <= toDate)
                .ToList();

            float tongTien = hoaDons.Sum(h => h.TongTien);

            return Ok(tongTien);
        }

        [HttpGet("revenue-in-month/{month}/{year}")]
        public IActionResult TinhTongTienTrongThang(int month, int year)
        {
            DateTime fromDate = new DateTime(year, month, 1);
            DateTime toDate = fromDate.AddMonths(1).AddDays(-1);

            var hoaDons = _context.HoaDon
                .Where(h => h.NgayDen >= fromDate && h.NgayDi <= toDate)
                .ToList();

            float tongTien = hoaDons.Sum(h => h.TongTien);

            return Ok(tongTien);
        }

        [HttpGet("low-demand-room/{formDate}/{toDate}/{minimum}")]
        public IActionResult ThongKePhongItDat(DateTime formDate, DateTime toDate, int minimum)
        {
            var danhSachPhongItDat = _context.DatPhong
                .Where(dp => dp.NgayNhan >= formDate && dp.NgayTra <= toDate)
                .GroupBy(dp => dp.MaPhong)
                .Where(group => group.Count() >= minimum)
                .OrderBy(group => group.Count())
                .Take(10)
                .Select(group => new
                {
                    MaPhong = group.Key,
                    SoLuongDat = group.Count()
                })
                .ToList();

            return Ok(danhSachPhongItDat);
        }

        [HttpGet("low-demand-room-month/{month}/{minimum}")]
        public IActionResult ThongKePhongItDatThang(int month, int minimum)
        {
            var danhSachPhongItDat = _context.DatPhong
                .Where(hd => hd.NgayNhan.Month == month)
                .GroupBy(hd => hd.MaPhong)
                .Where(group => group.Count() >= minimum)
                .OrderBy(group => group.Count())
                .Take(10)
                .Select(group => new
                {
                    MaPhong = group.Key,
                    SoLuongDat = group.Count()
                })
                .ToList();

            return Ok(danhSachPhongItDat);
        }


    }
}
