namespace NTNUntappd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatecheckinthings : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CheckInModels", "UserEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CheckInModels", "UserEmail", c => c.String());
        }
    }
}
