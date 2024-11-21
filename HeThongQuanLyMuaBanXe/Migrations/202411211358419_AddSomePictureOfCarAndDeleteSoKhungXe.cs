namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSomePictureOfCarAndDeleteSoKhungXe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Xes", "HinhAnh2", c => c.String());
            AddColumn("dbo.Xes", "HinhAnh3", c => c.String());
            AddColumn("dbo.Xes", "HinhAnh4", c => c.String());
            AddColumn("dbo.Xes", "MoTa", c => c.String());
            AddColumn("dbo.Xes", "TrangThai", c => c.String());
            DropColumn("dbo.Xes", "SoMayXe");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Xes", "SoMayXe", c => c.String(nullable: false));
            DropColumn("dbo.Xes", "TrangThai");
            DropColumn("dbo.Xes", "MoTa");
            DropColumn("dbo.Xes", "HinhAnh4");
            DropColumn("dbo.Xes", "HinhAnh3");
            DropColumn("dbo.Xes", "HinhAnh2");
        }
    }
}
