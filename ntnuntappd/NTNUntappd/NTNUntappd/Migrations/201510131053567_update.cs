namespace NTNUntappd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CheckInModels", "UserEmail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CheckInModels", "UserEmail");
        }
    }
}
