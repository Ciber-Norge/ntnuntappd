namespace CiBeer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class checkin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckInModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        BeerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeerModels", t => t.BeerId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.BeerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInModels", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CheckInModels", "BeerId", "dbo.BeerModels");
            DropIndex("dbo.CheckInModels", new[] { "BeerId" });
            DropIndex("dbo.CheckInModels", new[] { "UserId" });
            DropTable("dbo.CheckInModels");
        }
    }
}
