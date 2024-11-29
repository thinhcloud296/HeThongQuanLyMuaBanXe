namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNhaCCAndTTDV : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.NhaCungCaps",
                c => new
                    {
                        MaNhaCungCap = c.String(nullable: false, maxLength: 128),
                        TenNhaCungCap = c.String(),
                        DiaChiNhaCungCap = c.String(),
                        SoDienThoaiNhaCungCap = c.String(),
                        EmailNhaCungCap = c.String(),
                    })
                .PrimaryKey(t => t.MaNhaCungCap);
            
            CreateTable(
                "dbo.ThongTinDichVus",
                c => new
                    {
                        MaDichVu = c.String(nullable: false, maxLength: 128),
                        TenDichVu = c.String(),
                        MoTaDichVu = c.String(),
                        AnhDichVu = c.String(),
                    })
                .PrimaryKey(t => t.MaDichVu);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ThongTinDichVus");
            DropTable("dbo.NhaCungCaps");
        }
    }
}
