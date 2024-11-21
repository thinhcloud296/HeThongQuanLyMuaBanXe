namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.HoaDonBanHangs",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        MaHopDong = c.Int(nullable: false),
                        NgayLapHoaDon = c.DateTime(),
                        TongSoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThueVAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoTienThanhToan = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaHoaDon)
                .ForeignKey("dbo.HopDongMuaBans", t => t.MaHopDong, cascadeDelete: true)
                .Index(t => t.MaHopDong);
            
            CreateTable(
                "dbo.HopDongMuaBans",
                c => new
                    {
                        MaHopDong = c.Int(nullable: false, identity: true),
                        MaKhachHang = c.Int(nullable: false),
                        MaXe = c.Int(nullable: false),
                        NgayLapHopDong = c.DateTime(nullable: false),
                        DieuKhoanHopDong = c.String(nullable: false),
                        TongGiaTriHopDong = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaHopDong)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang, cascadeDelete: true)
                .ForeignKey("dbo.Xes", t => t.MaXe, cascadeDelete: true)
                .Index(t => t.MaKhachHang)
                .Index(t => t.MaXe);
            
            CreateTable(
                "dbo.KhachHangs",
                c => new
                    {
                        MaKhachHang = c.Int(nullable: false, identity: true),
                        HoTenKhachHang = c.String(nullable: false),
                        DiaChiKhachHang = c.String(nullable: false),
                        SoDienThoaiKhachHang = c.String(nullable: false),
                        EmailKhachHang = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MaKhachHang);
            
            CreateTable(
                "dbo.Xes",
                c => new
                    {
                        MaXe = c.Int(nullable: false, identity: true),
                        TenXe = c.String(nullable: false),
                        HangXe = c.String(nullable: false),
                        DongXe = c.String(nullable: false),
                        SoKhungXe = c.String(nullable: false),
                        SoMayXe = c.String(nullable: false),
                        MauSac = c.String(nullable: false),
                        NamSanXuat = c.Int(nullable: false),
                        GiaBanXe = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HinhAnh = c.String(),
                    })
                .PrimaryKey(t => t.MaXe);
            
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.Int(nullable: false, identity: true),
                        TenNhaCungCap = c.String(nullable: false),
                        DiaChiNhaCungCap = c.String(nullable: false),
                        SoDienThoaiNhaCungCap = c.String(nullable: false),
                        EmailNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
            CreateTable(
                "dbo.PhieuNhapKhoes",
                c => new
                    {
                        MaPhieuNhap = c.Int(nullable: false, identity: true),
                        MaXe = c.String(),
                        MaNhaCungCap = c.String(),
                        NgayNhap = c.DateTime(),
                        SoLuongNhap = c.Int(nullable: false),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NhaCungCap_MaNhaCungCap = c.Int(),
                        Xe_MaXe = c.Int(),
                    })
                .PrimaryKey(t => t.MaPhieuNhap)
                .ForeignKey("dbo.NhaCungCaps", t => t.NhaCungCap_MaNhaCungCap)
                .ForeignKey("dbo.Xes", t => t.Xe_MaXe)
                .Index(t => t.NhaCungCap_MaNhaCungCap)
                .Index(t => t.Xe_MaXe);
            
            CreateTable(
                "dbo.PhieuXuatKhoes",
                c => new
                    {
                        MaPhieuXuat = c.Int(nullable: false, identity: true),
                        MaXe = c.Int(nullable: false),
                        MaKhachHang = c.Int(nullable: false),
                        NgayXuat = c.DateTime(),
                        SoLuongXuat = c.Int(nullable: false),
                        GiaXuat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaPhieuXuat)
                .ForeignKey("dbo.KhachHangs", t => t.MaKhachHang, cascadeDelete: true)
                .ForeignKey("dbo.Xes", t => t.MaXe, cascadeDelete: true)
                .Index(t => t.MaXe)
                .Index(t => t.MaKhachHang);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuXuatKhoes", "MaXe", "dbo.Xes");
            DropForeignKey("dbo.PhieuXuatKhoes", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuNhapKhoes", "Xe_MaXe", "dbo.Xes");
            DropForeignKey("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap", "dbo.NhaCungCaps");
            DropForeignKey("dbo.HoaDonBanHangs", "MaHopDong", "dbo.HopDongMuaBans");
            DropForeignKey("dbo.HopDongMuaBans", "MaXe", "dbo.Xes");
            DropForeignKey("dbo.HopDongMuaBans", "MaKhachHang", "dbo.KhachHangs");
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaKhachHang" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaXe" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "Xe_MaXe" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "NhaCungCap_MaNhaCungCap" });
            DropIndex("dbo.HopDongMuaBans", new[] { "MaXe" });
            DropIndex("dbo.HopDongMuaBans", new[] { "MaKhachHang" });
            DropIndex("dbo.HoaDonBanHangs", new[] { "MaHopDong" });
            DropTable("dbo.PhieuXuatKhoes");
            DropTable("dbo.PhieuNhapKhoes");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.Xes");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.HopDongMuaBans");
            DropTable("dbo.HoaDonBanHangs");
        }
    }
}
