using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class DatPhong
    {
        [Key]
        public int MaDatphong { get; set; }
        public DateTime NgayDat { get; set; } = DateTime.Now;
        [Required]
        public DateTime NgayNhan { get; set; }
        [Required]
        public DateTime NgayTra { get; set; }
        [Required]
        public string? TrangThai { get; set; }
        public int MaPhong { get; set; }
        public Phong? Phong { get; set; }

        [Required, MaxLength(50)]
        public string? TenKhachHang { get; set; }
        [Required, MaxLength(10)]
        public string? SoDienThoai { get; set; }
        [Required, MaxLength(50)]
        public string? Email { get; set; }
        [Required, MaxLength(12)]
        public string? SoDinhDanh { get; set; }
    }
}
