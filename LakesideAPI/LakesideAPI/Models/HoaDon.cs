using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class HoaDon
    {
        [Key]
        public int MaHoaDon { get; set; }
        [Required, MaxLength(50)]
        public string? KhachHang { get; set; }
        public string? TenPhong { get; set; }
        public DateTime NgayDen { get; set; }
        public DateTime NgayDi { get; set; }
        public int SoNgayDat { get; set; }
        public float GiaPhong { get; set; }
        public float TongTien { get; set; }
        public int MaPhuongThuc { get; set; }
        public PhuongThucThanhToan? PhuongThucThanhToan { get; set; }
        public int MaDatPhong { get; set; }
        public DatPhong? DatPhong { get; set; }
    }
}
