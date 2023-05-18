namespace LakesideAPI.Response
{
    public class DatPhongResponse
    {
        public int MaDatPhong { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayNhan { get; set; }
        public DateTime NgayTra { get; set; }
        public string? TrangThai { get; set; }
        public string? TenKhachHang { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Email { get; set; }
        public string? SoDinhDanh { get; set; }

        public PhongResponse? Phong { get; set; }
    }
}
