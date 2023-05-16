using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class Phong
    {
        [Key]
        public int MaPhong { get; set; }
        [Required, MaxLength(100)]
        public string? TenPhong { get; set; }
        public int MaLoaiPhong { get; set; }
        public LoaiPhong? LoaiPhong { get; set; }
    }
}
