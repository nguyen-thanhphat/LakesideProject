using LakesideAPI.Models;

namespace LakesideAPI.Requests
{
    public class AddHoaDon
    {
        public string? KhachHang { get; set; }
        public DateTime NgayDen { get; set; }
        public DateTime NgayDi { get; set; }
        public int MaDatPhong { get; set; }
        public string? TenPhong { get; set; }
        public string? LoaiPhong { get; set; }
        public int MaPhuongThuc { get; set; }

        public float GiaPhong { get; set; }
        public int SoNgayDat { get; set; }
        public float TongTien { get; set; }
    }
}
