using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Requests
{
    public class AddDatPhong
    {
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public int MaPhong { get; set; }
        //Info Custommer
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? SoDinhDanh { get; set; }
    }
}
