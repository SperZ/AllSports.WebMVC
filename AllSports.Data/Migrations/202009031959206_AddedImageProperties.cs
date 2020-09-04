namespace AllSports.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageProperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Team", "Contents", c => c.Binary());
            AddColumn("dbo.Player", "Contents", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Player", "Contents");
            DropColumn("dbo.Team", "Contents");
        }
    }
}
