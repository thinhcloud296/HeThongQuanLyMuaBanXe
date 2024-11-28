namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdjustMaNhanVienToString : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.HopDongMuaBans", "NhanVien_MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien", "dbo.NhanViens");
            DropIndex("dbo.HopDongMuaBans", new[] { "NhanVien_MaNhanVien" });
            DropIndex("dbo.PhieuXuatKhoes", new[] { "NhanVien_MaNhanVien" });
            DropColumn("dbo.HopDongMuaBans", "MaNhanVien");
            DropColumn("dbo.PhieuXuatKhoes", "MaNhanVien");
            RenameColumn(table: "dbo.HopDongMuaBans", name: "NhanVien_MaNhanVien", newName: "MaNhanVien");
            RenameColumn(table: "dbo.PhieuXuatKhoes", name: "NhanVien_MaNhanVien", newName: "MaNhanVien");
            DropPrimaryKey("dbo.NhanViens");
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String(maxLength: 128));
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String(maxLength: 128));
            AlterColumn("dbo.NhanViens", "MaNhanVien", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String(maxLength: 128));
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.NhanViens", "MaNhanVien");
            CreateIndex("dbo.HopDongMuaBans", "MaNhanVien");
            CreateIndex("dbo.PhieuXuatKhoes", "MaNhanVien");
            AddForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens", "MaNhanVien");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuXuatKhoes", "MaNhanVien", "dbo.NhanViens");
            DropForeignKey("dbo.HopDongMuaBans", "MaNhanVien", "dbo.NhanViens");
            DropIndex("dbo.PhieuXuatKhoes", new[] { "MaNhanVien" });
            DropIndex("dbo.HopDongMuaBans", new[] { "MaNhanVien" });
            DropPrimaryKey("dbo.NhanViens");
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.Int());
            AlterColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String());
            AlterColumn("dbo.NhanViens", "MaNhanVien", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.Int());
            AlterColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String());
            AddPrimaryKey("dbo.NhanViens", "MaNhanVien");
            RenameColumn(table: "dbo.PhieuXuatKhoes", name: "MaNhanVien", newName: "NhanVien_MaNhanVien");
            RenameColumn(table: "dbo.HopDongMuaBans", name: "MaNhanVien", newName: "NhanVien_MaNhanVien");
            AddColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String());
            AddColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String());
            CreateIndex("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien");
            CreateIndex("dbo.HopDongMuaBans", "NhanVien_MaNhanVien");
            AddForeignKey("dbo.PhieuXuatKhoes", "NhanVien_MaNhanVien", "dbo.NhanViens", "MaNhanVien");
            AddForeignKey("dbo.HopDongMuaBans", "NhanVien_MaNhanVien", "dbo.NhanViens", "MaNhanVien");
        }
    }
}
