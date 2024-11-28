namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTrangThaiHopDong : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.HopDongMuaBans", "TrangThaiHopDong", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.HopDongMuaBans", "TrangThaiHopDong");
        }
    }
}
