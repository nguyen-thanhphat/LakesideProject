using LakesideAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LakesideAPI.Helpers
{
    public class AppDbContext : DbContext
    {
        public DbSet<LoaiPhong> LoaiPhong { get; set; }
        public DbSet<Phong> Phong { get; set; }
        public DbSet<DatPhong> DatPhong { get; set; }
        public DbSet<HoaDon> HoaDon { get; set; }
        public DbSet<PhuongThucThanhToan> PhuongthucThanhtoan { get; set; }
        public DbSet<GioiThieu> GioiThieu { get; set; }
        public DbSet<PhanHoi> PhanHoi { get; set; }
        public DbSet<ThongTin> ThongTin { get; set; }
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Phong>()
                .HasOne(p => p.LoaiPhong)
                .WithMany()
                .HasForeignKey(p => p.MaLoaiPhong);

            modelBuilder.Entity<DatPhong>()
                .HasOne(dp => dp.Phong)
                .WithMany()
                .HasForeignKey(dp => dp.MaPhong);

            // Ánh xạ quan hệ giữa HoaDon và PhuongThucThanhToan
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.PhuongThucThanhToan)
                .WithMany()
                .HasForeignKey(hd => hd.MaPhuongThuc);

            // Ánh xạ quan hệ giữa HoaDon và DatPhong
            modelBuilder.Entity<HoaDon>()
                .HasOne(hd => hd.DatPhong)
                .WithMany()
                .HasForeignKey(hd => hd.MaDatPhong);
        }
    }
}
