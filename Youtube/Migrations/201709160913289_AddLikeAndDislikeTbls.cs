namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLikeAndDislikeTbls : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dislikes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        VideoId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VideoId);
            
            CreateTable(
                "dbo.Likes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        VideoId = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.VideoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Likes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Dislikes", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.Dislikes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Likes", new[] { "VideoId" });
            DropIndex("dbo.Likes", new[] { "UserId" });
            DropIndex("dbo.Dislikes", new[] { "VideoId" });
            DropIndex("dbo.Dislikes", new[] { "UserId" });
            DropTable("dbo.Likes");
            DropTable("dbo.Dislikes");
        }
    }
}
