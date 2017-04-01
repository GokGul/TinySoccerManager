namespace TinySoccerManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateCountryPositionTournamentPouleTeam : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Tournament(Name) VALUES('WK2014')");

            Sql("INSERT INTO Country(Name, ShortName) VALUES('Nederland', 'NED')");
            Sql("INSERT INTO Country(Name, ShortName) VALUES('Spanje', 'ESP')");
            Sql("INSERT INTO Country(Name, ShortName) VALUES('Australië', 'AUS')");
            Sql("INSERT INTO Country(Name, ShortName) VALUES('Chili', 'CHL')");

            Sql("INSERT INTO Position(Name, ShortName) VALUES('Doelman', 'DM')");
            Sql("INSERT INTO Position(Name, ShortName) VALUES('Verdediger', 'VER')");
            Sql("INSERT INTO Position(Name, ShortName) VALUES('Middenvelder', 'MID')");
            Sql("INSERT INTO Position(Name, ShortName) VALUES('Aanvaller', 'AAN')");

            Sql("INSERT INTO Poule(Name, Tournament_Id) VALUES('E', 1)");

            Sql("INSERT INTO Team(Country_Id) VALUES(1)");
            Sql("INSERT INTO Team(Country_Id) VALUES(2)");
            Sql("INSERT INTO Team(Country_Id) VALUES(3)");
            Sql("INSERT INTO Team(Country_Id) VALUES(4)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Tournament WHERE Id IN (1)");

            Sql("DELETE FROM Country WHERE Id IN (1, 2, 3, 4)");

            Sql("DELETE FROM Position WHERE Id IN (1, 2, 3, 4)");

            Sql("DELETE FROM Poule WHERE Id IN (1)");

            Sql("DELETE FROM Team WHERE Id IN (1, 2, 3, 4)");
        }
    }
}
