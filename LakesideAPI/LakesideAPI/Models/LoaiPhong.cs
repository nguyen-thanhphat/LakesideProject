using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class LoaiPhong
    {
        [Key]
        public int MaLoaiPhong { get; set; }

        [Required, MaxLength(255)]
        public string? TenLoaiPhong { get; set; }
        public string? TienIch { get; set; }
        public string? NhinRa { get; set; }
        public string? KichCo { get; set; }
        [Required]
        public float GiaPhong { get; set; }
        public string? UrlImage { get; set; }
        public int SucChua { get; set; }
        public float PhuThu { get; set; }
    }
}
