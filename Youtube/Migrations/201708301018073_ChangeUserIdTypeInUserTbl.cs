namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeUserIdTypeInUserTbl : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Videos", new[] { "User_Id" });
            DropColumn("dbo.Videos", "UserId");
            RenameColumn(table: "dbo.Videos", name: "User_Id", newName: "UserId");
            AlterColumn("dbo.Videos", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Videos", "UserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Videos", new[] { "UserId" });
            AlterColumn("dbo.Videos", "UserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Videos", name: "UserId", newName: "User_Id");
            AddColumn("dbo.Videos", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Videos", "User_Id");
        }
    }
}
