namespace HeThongQuanLyMuaBanXe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFavourite : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaXe = c.Int(nullable: false),
                        SoLuong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Xes", t => t.MaXe, cascadeDelete: true)
                .Index(t => t.MaXe);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "MaXe", "dbo.Xes");
            DropIndex("dbo.Favourites", new[] { "MaXe" });
            DropTable("dbo.Favourites");
        }
    }
}
