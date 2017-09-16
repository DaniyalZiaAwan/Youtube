namespace Youtube.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddChannelCOlInUserTbl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Channel", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Channel");
        }
    }
}
