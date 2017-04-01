namespace TinySoccerManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateAllTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Country",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GameResult",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Goals = c.Int(nullable: false),
                        Yellow = c.Int(nullable: false),
                        Red = c.Int(nullable: false),
                        Player_Id = c.Int(),
                        Game_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.Player_Id)
                .ForeignKey("dbo.Game", t => t.Game_Id)
                .Index(t => t.Player_Id)
                .Index(t => t.Game_Id);
            
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Result = c.String(),
                        Team_Id = c.Int(),
                        Poule_Id = c.Int(),
                        Away_Id = c.Int(),
                        Home_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Team", t => t.Team_Id)
                .ForeignKey("dbo.Poule", t => t.Poule_Id)
                .ForeignKey("dbo.Team", t => t.Away_Id)
                .ForeignKey("dbo.Team", t => t.Home_Id)
                .Index(t => t.Team_Id)
                .Index(t => t.Poule_Id)
                .Index(t => t.Away_Id)
                .Index(t => t.Home_Id);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Country", t => t.Country_Id)
                .Index(t => t.Country_Id);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        ShirtNumber = c.Int(nullable: false),
                        GkRating = c.Int(nullable: false),
                        DefRating = c.Int(nullable: false),
                        FwdRating = c.Int(nullable: false),
                        Position_Id = c.Int(),
                        Team_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Position", t => t.Position_Id)
                .ForeignKey("dbo.Team", t => t.Team_Id)
                .Index(t => t.Position_Id)
                .Index(t => t.Team_Id);
            
            CreateTable(
                "dbo.Position",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ShortName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Poule",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Tournament_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tournament", t => t.Tournament_Id)
                .Index(t => t.Tournament_Id);
            
            CreateTable(
                "dbo.Tournament",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PouleTeam",
                c => new
                    {
                        Poule_Id = c.Int(nullable: false),
                        Team_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Poule_Id, t.Team_Id })
                .ForeignKey("dbo.Poule", t => t.Poule_Id, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.Team_Id, cascadeDelete: true)
                .Index(t => t.Poule_Id)
                .Index(t => t.Team_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Game", "Home_Id", "dbo.Team");
            DropForeignKey("dbo.GameResult", "Game_Id", "dbo.Game");
            DropForeignKey("dbo.Game", "Away_Id", "dbo.Team");
            DropForeignKey("dbo.Poule", "Tournament_Id", "dbo.Tournament");
            DropForeignKey("dbo.PouleTeam", "Team_Id", "dbo.Team");
            DropForeignKey("dbo.PouleTeam", "Poule_Id", "dbo.Poule");
            DropForeignKey("dbo.Game", "Poule_Id", "dbo.Poule");
            DropForeignKey("dbo.Player", "Team_Id", "dbo.Team");
            DropForeignKey("dbo.Player", "Position_Id", "dbo.Position");
            DropForeignKey("dbo.GameResult", "Player_Id", "dbo.Player");
            DropForeignKey("dbo.Game", "Team_Id", "dbo.Team");
            DropForeignKey("dbo.Team", "Country_Id", "dbo.Country");
            DropIndex("dbo.PouleTeam", new[] { "Team_Id" });
            DropIndex("dbo.PouleTeam", new[] { "Poule_Id" });
            DropIndex("dbo.Poule", new[] { "Tournament_Id" });
            DropIndex("dbo.Player", new[] { "Team_Id" });
            DropIndex("dbo.Player", new[] { "Position_Id" });
            DropIndex("dbo.Team", new[] { "Country_Id" });
            DropIndex("dbo.Game", new[] { "Home_Id" });
            DropIndex("dbo.Game", new[] { "Away_Id" });
            DropIndex("dbo.Game", new[] { "Poule_Id" });
            DropIndex("dbo.Game", new[] { "Team_Id" });
            DropIndex("dbo.GameResult", new[] { "Game_Id" });
            DropIndex("dbo.GameResult", new[] { "Player_Id" });
            DropTable("dbo.PouleTeam");
            DropTable("dbo.Tournament");
            DropTable("dbo.Poule");
            DropTable("dbo.Position");
            DropTable("dbo.Player");
            DropTable("dbo.Team");
            DropTable("dbo.Game");
            DropTable("dbo.GameResult");
            DropTable("dbo.Country");
        }
    }
}
