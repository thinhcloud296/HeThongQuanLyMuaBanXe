using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace HeThongQuanLyMuaBanXe.Models
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext() : base("MyCS") { }
        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<NhaCungCap> NhaCungCaps { get; set; }
        public DbSet<Xe> Xes { get; set; }
        public DbSet<PhieuNhapKho> PhieuNhapKhos { get; set; }
        public DbSet<PhieuXuatKho> PhieuXuatKhos { get; set; }
        public DbSet<HopDongMuaBan> HopDongMuaBans { get; set; }
        public DbSet<HoaDonBanHang> HoaDonBanHangs { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Favourite> Favourites {  get; set; }
    }
}