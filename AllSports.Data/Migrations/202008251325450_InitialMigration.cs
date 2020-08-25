namespace AllSports.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Coach",
                c => new
                    {
                        CoachId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        YearsWithTeam = c.Int(),
                        College = c.String(),
                        CoachPosition = c.Int(nullable: false),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.CoachId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamId = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false),
                        Wins = c.Int(nullable: false),
                        Losses = c.Int(nullable: false),
                        CityName = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        LeagueId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeamId)
                .ForeignKey("dbo.League", t => t.LeagueId, cascadeDelete: true)
                .Index(t => t.LeagueId);
            
            CreateTable(
                "dbo.Fan",
                c => new
                    {
                        FanId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        State = c.Int(nullable: false),
                        CityName = c.String(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.FanId);
            
            CreateTable(
                "dbo.League",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        LeagueName = c.String(nullable: false),
                        NumberOfTeams = c.Int(nullable: false),
                        LeagueInception = c.Int(nullable: false),
                        BaseCountry = c.String(nullable: false),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.LeagueId)
                .ForeignKey("dbo.Sport", t => t.SportId, cascadeDelete: true)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Sport",
                c => new
                    {
                        SportId = c.Int(nullable: false, identity: true),
                        SportName = c.String(nullable: false),
                        YearInvented = c.Int(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.SportId);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false),
                        JerseyNumber = c.Int(),
                        Height = c.String(nullable: false),
                        Weight = c.Int(nullable: false),
                        YearsWithTeam = c.Int(),
                        College = c.String(),
                        TwitterHandle = c.String(),
                        TeamId = c.Int(),
                    })
                .PrimaryKey(t => t.PlayerId)
                .ForeignKey("dbo.Team", t => t.TeamId)
                .Index(t => t.TeamId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.FanTeam",
                c => new
                    {
                        Fan_FanId = c.Int(nullable: false),
                        Team_TeamId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Fan_FanId, t.Team_TeamId })
                .ForeignKey("dbo.Fan", t => t.Fan_FanId, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.Team_TeamId, cascadeDelete: true)
                .Index(t => t.Fan_FanId)
                .Index(t => t.Team_TeamId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Player", "TeamId", "dbo.Team");
            DropForeignKey("dbo.Team", "LeagueId", "dbo.League");
            DropForeignKey("dbo.League", "SportId", "dbo.Sport");
            DropForeignKey("dbo.FanTeam", "Team_TeamId", "dbo.Team");
            DropForeignKey("dbo.FanTeam", "Fan_FanId", "dbo.Fan");
            DropForeignKey("dbo.Coach", "TeamId", "dbo.Team");
            DropIndex("dbo.FanTeam", new[] { "Team_TeamId" });
            DropIndex("dbo.FanTeam", new[] { "Fan_FanId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Player", new[] { "TeamId" });
            DropIndex("dbo.League", new[] { "SportId" });
            DropIndex("dbo.Team", new[] { "LeagueId" });
            DropIndex("dbo.Coach", new[] { "TeamId" });
            DropTable("dbo.FanTeam");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Player");
            DropTable("dbo.Sport");
            DropTable("dbo.League");
            DropTable("dbo.Fan");
            DropTable("dbo.Team");
            DropTable("dbo.Coach");
        }
    }
}
