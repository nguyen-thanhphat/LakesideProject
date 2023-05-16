using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class GioiThieu
    {
        [Key]
        public int MaGioiThieu { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
    }
}
