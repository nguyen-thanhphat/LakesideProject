using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Models
{
    public class PhanHoi
    {
        [Key]
        public int MaPhanHoi { get; set; }
        public string? TieuDe { get; set; }
        public string? NoiDung { get; set; }
    }
}
