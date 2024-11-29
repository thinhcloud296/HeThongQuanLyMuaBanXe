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
        public DbSet<Xe> Xes { get; set; }
        public DbSet<HopDongMuaBan> HopDongMuaBans { get; set; }
        public DbSet<NhanVien> NhanViens { get; set; }
        public DbSet<Favourite> Favourites {  get; set; }
    }
}