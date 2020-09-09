namespace AllSports.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StoryClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Story",
                c => new
                    {
                        StoryId = c.Int(nullable: false, identity: true),
                        HeadLine = c.String(),
                        Content = c.String(),
                        CreatedUTC = c.DateTimeOffset(nullable: false, precision: 7),
                        UserName = c.String(),
                        PlayerId = c.Int(),
                    })
                .PrimaryKey(t => t.StoryId)
                .ForeignKey("dbo.Player", t => t.PlayerId)
                .Index(t => t.PlayerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Story", "PlayerId", "dbo.Player");
            DropIndex("dbo.Story", new[] { "PlayerId" });
            DropTable("dbo.Story");
        }
    }
}
