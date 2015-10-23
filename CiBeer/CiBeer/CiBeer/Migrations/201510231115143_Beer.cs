namespace CiBeer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Beer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BeerModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                        Brewery = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BeerModels");
        }
    }
}
