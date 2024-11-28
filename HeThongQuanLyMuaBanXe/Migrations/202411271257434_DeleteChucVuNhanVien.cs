namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteChucVuNhanVien : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.NhanViens", "ChucVuNhanVien");
        }
        
        public override void Down()
        {
            AddColumn("dbo.NhanViens", "ChucVuNhanVien", c => c.String(nullable: false));
        }
    }
}
