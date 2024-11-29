namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustModelHopDong : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HopDongMuaBans", "MaKhachHang", "dbo.KhachHangs");
            DropForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens");
            DropIndex("dbo.HopDongMuaBans", new[] { "MaKhachHang" });
            DropIndex("dbo.HopDongMuaBans", new[] { "MaNhanVien" });
            AddColumn("dbo.HopDongMuaBans", "HoTenKhachHang", c => c.String());
            AddColumn("dbo.HopDongMuaBans", "DiaChiKhachHang", c => c.String(nullable: false));
            AddColumn("dbo.HopDongMuaBans", "SoDienThoaiKhachHang", c => c.String(nullable: false));
            AddColumn("dbo.HopDongMuaBans", "EmailKhachHang", c => c.String(nullable: false));
            DropColumn("dbo.HopDongMuaBans", "MaKhachHang");
            DropColumn("dbo.HopDongMuaBans", "MaNhanVien");
            DropColumn("dbo.HopDongMuaBans", "DieuKhoanHopDong");
        }
        
        public override void Down()
        {
            AddColumn("dbo.HopDongMuaBans", "DieuKhoanHopDong", c => c.String(nullable: false));
            AddColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String(maxLength: 128));
            AddColumn("dbo.HopDongMuaBans", "MaKhachHang", c => c.Int(nullable: false));
            DropColumn("dbo.HopDongMuaBans", "EmailKhachHang");
            DropColumn("dbo.HopDongMuaBans", "SoDienThoaiKhachHang");
            DropColumn("dbo.HopDongMuaBans", "DiaChiKhachHang");
            DropColumn("dbo.HopDongMuaBans", "HoTenKhachHang");
            CreateIndex("dbo.HopDongMuaBans", "MaNhanVien");
            CreateIndex("dbo.HopDongMuaBans", "MaKhachHang");
            AddForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.HopDongMuaBans", "MaKhachHang", "dbo.KhachHangs", "MaKhachHang", cascadeDelete: true);
        }
    }
}
