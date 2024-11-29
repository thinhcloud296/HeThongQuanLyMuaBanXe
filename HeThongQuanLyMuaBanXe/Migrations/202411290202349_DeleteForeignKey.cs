namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HoaDonBanHangs", "MaHopDong", "dbo.HopDongMuaBans");
            DropForeignKey("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap", "dbo.NhaCungCaps");
            DropForeignKey("dbo.PhieuNhapKhoes", "Xe_MaXe", "dbo.Xes");
            DropForeignKey("dbo.PhieuXuatKhoes", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.PhieuXuatKhoes", "MaXe", "dbo.Xes");
            DropIndex("dbo.HoaDonBanHangs", new[] { "MaHopDong" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "NhaCungCap_MaNhaCungCap" });
            DropIndex("dbo.PhieuNhapKhoes", new[] { "Xe_MaXe" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaXe" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaKhachHang" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaNhanVien" });
            DropColumn("dbo.HoaDonBanHangs", "MaHopDong");
            DropColumn("dbo.PhieuNhapKhoes", "MaXe");
            DropColumn("dbo.PhieuNhapKhoes", "MaNhaCungCap");
            DropColumn("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap");
            DropColumn("dbo.PhieuNhapKhoes", "Xe_MaXe");
            DropColumn("dbo.PhieuXuatKhoes", "MaXe");
            DropColumn("dbo.PhieuXuatKhoes", "MaKhachHang");
            DropColumn("dbo.PhieuXuatKhoes", "MaNhanVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String(maxLength: 128));
            AddColumn("dbo.PhieuXuatKhoes", "MaKhachHang", c => c.Int(nullable: false));
            AddColumn("dbo.PhieuXuatKhoes", "MaXe", c => c.Int(nullable: false));
            AddColumn("dbo.PhieuNhapKhoes", "Xe_MaXe", c => c.Int());
            AddColumn("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap", c => c.Int());
            AddColumn("dbo.PhieuNhapKhoes", "MaNhaCungCap", c => c.String());
            AddColumn("dbo.PhieuNhapKhoes", "MaXe", c => c.String());
            AddColumn("dbo.HoaDonBanHangs", "MaHopDong", c => c.Int(nullable: false));
            CreateIndex("dbo.PhieuXuatKhoes", "MaNhanVien");
            CreateIndex("dbo.PhieuXuatKhoes", "MaKhachHang");
            CreateIndex("dbo.PhieuXuatKhoes", "MaXe");
            CreateIndex("dbo.PhieuNhapKhoes", "Xe_MaXe");
            CreateIndex("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap");
            CreateIndex("dbo.HoaDonBanHangs", "MaHopDong");
            AddForeignKey("dbo.PhieuXuatKhoes", "MaXe", "dbo.Xes", "MaXe", cascadeDelete: true);
            AddForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.PhieuXuatKhoes", "MaKhachHang", "dbo.KhachHangs", "MaKhachHang", cascadeDelete: true);
            AddForeignKey("dbo.PhieuNhapKhoes", "Xe_MaXe", "dbo.Xes", "MaXe");
            AddForeignKey("dbo.PhieuNhapKhoes", "NhaCungCap_MaNhaCungCap", "dbo.NhaCungCaps", "MaNhaCungCap");
            AddForeignKey("dbo.HoaDonBanHangs", "MaHopDong", "dbo.HopDongMuaBans", "MaHopDong", cascadeDelete: true);
        }
    }
}
