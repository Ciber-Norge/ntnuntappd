namespace NTNUntappd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CheckInModels", "Beer_Id", "dbo.BeerModels");
            DropIndex("dbo.CheckInModels", new[] { "Beer_Id" });
            RenameColumn(table: "dbo.CheckInModels", name: "Beer_Id", newName: "BeerId");
            RenameColumn(table: "dbo.CheckInModels", name: "UserId_Id", newName: "UserIdId");
            RenameIndex(table: "dbo.CheckInModels", name: "IX_UserId_Id", newName: "IX_UserIdId");
            AlterColumn("dbo.CheckInModels", "BeerId", c => c.Int(nullable: false));
            CreateIndex("dbo.CheckInModels", "BeerId");
            AddForeignKey("dbo.CheckInModels", "BeerId", "dbo.BeerModels", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CheckInModels", "BeerId", "dbo.BeerModels");
            DropIndex("dbo.CheckInModels", new[] { "BeerId" });
            AlterColumn("dbo.CheckInModels", "BeerId", c => c.Int());
            RenameIndex(table: "dbo.CheckInModels", name: "IX_UserIdId", newName: "IX_UserId_Id");
            RenameColumn(table: "dbo.CheckInModels", name: "UserIdId", newName: "UserId_Id");
            RenameColumn(table: "dbo.CheckInModels", name: "BeerId", newName: "Beer_Id");
            CreateIndex("dbo.CheckInModels", "Beer_Id");
            AddForeignKey("dbo.CheckInModels", "Beer_Id", "dbo.BeerModels", "Id");
        }
    }
}
