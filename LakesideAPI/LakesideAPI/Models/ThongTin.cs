using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class ThongTin
    {
        [Key]
        public int MaThongTin {  get; set; }
        public string? TieuDe { get; set; }     
        public string? NoiDung { get; set; }
        public DateTime NgayDang { get; set; } = DateTime.Now;
    }
}
