using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class PhuongThucThanhToan
    {
        [Key]
        public int MaPhuongThuc { get; set; }
        [Required, MaxLength(50)]
        public string? TenPhuongThuc { get; set; }
        public string? DoiTac { get; set; }
    }
}
