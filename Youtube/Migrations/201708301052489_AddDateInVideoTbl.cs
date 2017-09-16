namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateInVideoTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Videos", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Videos", "DateTime");
        }
    }
}
