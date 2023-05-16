using System.ComponentModel.DataAnnotations;

namespace LakesideAPI.Requests
{
    public class SearchPhong
    {
        public int MaPhong { get; set; }
        public string? TenPhong { get; set; }
        public string? TenLoaiPhong { get; set; }
        public string? TienIch { get; set; }
        public string? KichCo { get; set; }
        public float GiaPhong { get; set; }
        public string? UrlImage { get; set; }

        //Not show
        public string? NhinRa { get; set; }
        public int SucChua { get; set; }
        public float PhuThu { get; set; }
    }
}
