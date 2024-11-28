namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustMaNhanVienToInt : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens");
            DropIndex("dbo.HopDongMuaBans", new[] { "MaNhanVien" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaNhanVien" });
            DropPrimaryKey("dbo.NhanViens");
            AddColumn("dbo.HopDongMuaBans", "NhanVien_MaNhanVien", c => c.Int());
            AddColumn("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien", c => c.Int());
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String());
            AlterColumn("dbo.NhanViens", "MaNhanVien", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String());
            AddPrimaryKey("dbo.NhanViens", "MaNhanVien");
            CreateIndex("dbo.HopDongMuaBans", "NhanVien_MaNhanVien");
            CreateIndex("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien");
            AddForeignKey("dbo.HopDongMuaBans", "NhanVien_MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien", "dbo.NhanViens", "MaNhanVien");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.HopDongMuaBans", "NhanVien_MaNhanVien", "dbo.NhanViens");
            DropIndex("dbo.PhieuXuatKhoes", new[] { "NhanVien_MaNhanVien" });
            DropIndex("dbo.HopDongMuaBans", new[] { "NhanVien_MaNhanVien" });
            DropPrimaryKey("dbo.NhanViens");
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String(maxLength: 128));
            AlterColumn("dbo.NhanViens", "MaNhanVien", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String(maxLength: 128));
            DropColumn("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien");
            DropColumn("dbo.HopDongMuaBans", "NhanVien_MaNhanVien");
            AddPrimaryKey("dbo.NhanViens", "MaNhanVien");
            CreateIndex("dbo.PhieuXuatKhoes", "MaNhanVien");
            CreateIndex("dbo.HopDongMuaBans", "MaNhanVien");
            AddForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
        }
    }
}
