namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVideoTbl : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        Type = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Videos", new[] { "User_Id" });
            DropTable("dbo.Videos");
        }
    }
}
