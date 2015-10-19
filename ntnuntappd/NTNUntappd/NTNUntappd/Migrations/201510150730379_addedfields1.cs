namespace NTNUntappd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfields1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CheckInModels", name: "UserIdId", newName: "UserId");
            RenameIndex(table: "dbo.CheckInModels", name: "IX_UserIdId", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CheckInModels", name: "IX_UserId", newName: "IX_UserIdId");
            RenameColumn(table: "dbo.CheckInModels", name: "UserId", newName: "UserIdId");
        }
    }
}
