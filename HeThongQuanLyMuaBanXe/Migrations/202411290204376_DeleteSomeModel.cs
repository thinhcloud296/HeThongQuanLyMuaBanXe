namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSomeModel : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.HoaDonBanHangs");
            DropTable("dbo.KhachHangs");
            DropTable("dbo.NhaCungCaps");
            DropTable("dbo.PhieuNhapKhoes");
            DropTable("dbo.PhieuXuatKhoes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PhieuXuatKhoes",
                c => new
                    {
                        MaPhieuXuat = c.Int(nullable: false, identity: true),
                        NgayXuat = c.DateTime(),
                        SoLuongXuat = c.Int(nullable: false),
                        GiaXuat = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaPhieuXuat);
            
            CreateTable(
                "dbo.PhieuNhapKhoes",
                c => new
                    {
                        MaPhieuNhap = c.Int(nullable: false, identity: true),
                        NgayNhap = c.DateTime(),
                        SoLuongNhap = c.Int(nullable: false),
                        GiaNhap = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaPhieuNhap);
            
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
                "dbo.HoaDonBanHangs",
                c => new
                    {
                        MaHoaDon = c.Int(nullable: false, identity: true),
                        NgayLapHoaDon = c.DateTime(),
                        TongSoTien = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThueVAT = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SoTienThanhToan = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MaHoaDon);
            
        }
    }
}
