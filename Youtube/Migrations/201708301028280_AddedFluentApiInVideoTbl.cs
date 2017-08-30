namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedFluentApiInVideoTbl : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Videos", new[] { "UserId" });
            AlterColumn("dbo.Videos", "Title", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "Url", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Videos", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Videos", "UserId");
            AddForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Videos", new[] { "UserId" });
            AlterColumn("dbo.Videos", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Videos", "Url", c => c.String());
            AlterColumn("dbo.Videos", "Title", c => c.String());
            CreateIndex("dbo.Videos", "UserId");
            AddForeignKey("dbo.Videos", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
