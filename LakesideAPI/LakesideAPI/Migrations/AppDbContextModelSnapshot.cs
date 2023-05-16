﻿// <auto-generated />
using System;
using LakesideAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LakesideAPI.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LakesideAPI.Models.DatPhong", b =>
                {
                    b.Property<int>("MaDatphong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaDatphong"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaPhong")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDat")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayNhan")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayTra")
                        .HasColumnType("datetime2");

                    b.Property<string>("SoDienThoai")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("SoDinhDanh")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<string>("TenKhachHang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrangThai")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaDatphong");

                    b.HasIndex("MaPhong");

                    b.ToTable("DatPhong");
                });

            modelBuilder.Entity("LakesideAPI.Models.GioiThieu", b =>
                {
                    b.Property<int>("MaGioiThieu")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaGioiThieu"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaGioiThieu");

                    b.ToTable("GioiThieu");
                });

            modelBuilder.Entity("LakesideAPI.Models.HoaDon", b =>
                {
                    b.Property<int>("MaHoaDon")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaHoaDon"), 1L, 1);

                    b.Property<float>("GiaPhong")
                        .HasColumnType("real");

                    b.Property<string>("KhachHang")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaDatPhong")
                        .HasColumnType("int");

                    b.Property<int>("MaPhuongThuc")
                        .HasColumnType("int");

                    b.Property<DateTime>("NgayDen")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("NgayDi")
                        .HasColumnType("datetime2");

                    b.Property<int>("SoNgayDat")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("TongTien")
                        .HasColumnType("real");

                    b.HasKey("MaHoaDon");

                    b.HasIndex("MaDatPhong");

                    b.HasIndex("MaPhuongThuc");

                    b.ToTable("HoaDon");
                });

            modelBuilder.Entity("LakesideAPI.Models.LoaiPhong", b =>
                {
                    b.Property<int>("MaLoaiPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaLoaiPhong"), 1L, 1);

                    b.Property<float>("GiaPhong")
                        .HasColumnType("real");

                    b.Property<string>("KichCo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NhinRa")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("PhuThu")
                        .HasColumnType("real");

                    b.Property<int>("SucChua")
                        .HasColumnType("int");

                    b.Property<string>("TenLoaiPhong")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("TienIch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UrlImage")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaLoaiPhong");

                    b.ToTable("LoaiPhong");
                });

            modelBuilder.Entity("LakesideAPI.Models.PhanHoi", b =>
                {
                    b.Property<int>("MaPhanHoi")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhanHoi"), 1L, 1);

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaPhanHoi");

                    b.ToTable("PhanHoi");
                });

            modelBuilder.Entity("LakesideAPI.Models.Phong", b =>
                {
                    b.Property<int>("MaPhong")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhong"), 1L, 1);

                    b.Property<int>("MaLoaiPhong")
                        .HasColumnType("int");

                    b.Property<string>("TenPhong")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("MaPhong");

                    b.HasIndex("MaLoaiPhong");

                    b.ToTable("Phong");
                });

            modelBuilder.Entity("LakesideAPI.Models.PhuongThucThanhToan", b =>
                {
                    b.Property<int>("MaPhuongThuc")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaPhuongThuc"), 1L, 1);

                    b.Property<string>("DoiTac")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TenPhuongThuc")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MaPhuongThuc");

                    b.ToTable("PhuongthucThanhtoan");
                });

            modelBuilder.Entity("LakesideAPI.Models.ThongTin", b =>
                {
                    b.Property<int>("MaThongTin")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaThongTin"), 1L, 1);

                    b.Property<DateTime>("NgayDang")
                        .HasColumnType("datetime2");

                    b.Property<string>("NoiDung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TieuDe")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaThongTin");

                    b.ToTable("ThongTin");
                });

            modelBuilder.Entity("LakesideAPI.Models.DatPhong", b =>
                {
                    b.HasOne("LakesideAPI.Models.Phong", "Phong")
                        .WithMany()
                        .HasForeignKey("MaPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Phong");
                });

            modelBuilder.Entity("LakesideAPI.Models.HoaDon", b =>
                {
                    b.HasOne("LakesideAPI.Models.DatPhong", "DatPhong")
                        .WithMany()
                        .HasForeignKey("MaDatPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LakesideAPI.Models.PhuongThucThanhToan", "PhuongThucThanhToan")
                        .WithMany()
                        .HasForeignKey("MaPhuongThuc")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DatPhong");

                    b.Navigation("PhuongThucThanhToan");
                });

            modelBuilder.Entity("LakesideAPI.Models.Phong", b =>
                {
                    b.HasOne("LakesideAPI.Models.LoaiPhong", "LoaiPhong")
                        .WithMany()
                        .HasForeignKey("MaLoaiPhong")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LoaiPhong");
                });
#pragma warning restore 612, 618
        }
    }
}
