namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNhanVien : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhanViens",
                c => new
                    {
                        MaNhanVien = c.String(nullable: false, maxLength: 128),
                        TenNhanVien = c.String(nullable: false),
                        ChucVuNhanVien = c.String(nullable: false),
                        DiaChiNhanVien = c.String(nullable: false),
                        SoDienThoaiNhanVien = c.String(nullable: false),
                        EmailNhanVien = c.String(nullable: false),
                        TenDangNhap = c.String(nullable: false),
                        MatKhau = c.String(nullable: false),
                        VaiTro = c.String(),
                    })
                .PrimaryKey(t => t.MaNhanVien);
            
            AddColumn("dbo.HopDongMuaBans", "MaNhanVien", c => c.String(maxLength: 128));
            AddColumn("dbo.PhieuXuatKhoes", "MaNhanVien", c => c.String(maxLength: 128));
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
            DropColumn("dbo.PhieuXuatKhoes", "MaNhanVien");
            DropColumn("dbo.HopDongMuaBans", "MaNhanVien");
            DropTable("dbo.NhanViens");
        }
    }
}
