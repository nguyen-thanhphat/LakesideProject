using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Response
{
    public class LoaiPhongResponse
    {
        public int MaLoaiPhong { get; set; }
        public string? TenLoaiPhong { get; set; }
        public string? TienIch { get; set; }
        public string? KichCo { get; set; }
        public float GiaPhong { get; set; }
        public string? NhinRa { get; set; }
        public int SucChua { get; set; }
        public float PhuThu { get; set; }
    }
}
