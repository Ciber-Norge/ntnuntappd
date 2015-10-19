namespace NTNUntappd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class beer1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CheckInModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Beer_Id = c.Int(),
                        UserId_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BeerModels", t => t.Beer_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId_Id)
                .Index(t => t.Beer_Id)
                .Index(t => t.UserId_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInModels", "UserId_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.CheckInModels", "Beer_Id", "dbo.BeerModels");
            DropIndex("dbo.CheckInModels", new[] { "UserId_Id" });
            DropIndex("dbo.CheckInModels", new[] { "Beer_Id" });
            DropTable("dbo.CheckInModels");
        }
    }
}
