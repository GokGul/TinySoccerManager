namespace TinySoccerManager.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulatePlayers : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Jasper', 'Cillessen', 1, 81, 0, 0, 1, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Ron', 'Vlaar', 2, 0, 80, 57, 2, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Stefan', 'Vrij', 3, 0, 84, 41, 2, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Bruno', 'Martins', 4, 0, 84, 43, 2, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Darryl', 'Janmaat', 7, 0, 74, 63, 2, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Daley', 'Blind', 5, 0, 81, 56, 3, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Nigel', 'Jong', 8, 0, 75, 51, 3, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Jonathan', 'Guzman', 14, 0, 50, 74, 3, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Wesley', 'Sneijder', 25, 0, 38, 78, 3, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Arjen', 'Robben', 11, 0, 32, 85, 4, 1)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Robin', 'Persie', 9, 0, 33, 84, 4, 1)");

            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Iker', 'Casillas', 1, 83, 0, 0, 1, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Gerard', 'Pique', 2, 0, 86, 61, 2, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Sergio', 'Ramos', 3, 0, 87, 63, 2, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Jordi', 'Alba', 4, 0, 81, 69, 2, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Cesar', 'Azpilicueta', 7, 0, 84, 57, 2, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Andres', 'Iniesta', 5, 0, 59, 75, 3, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Sergio', 'Busquets', 8, 0, 83, 59, 3, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Xavi', 'Hernandez', 14, 0, 60, 72, 3, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Xabi', 'Alonso', 25, 0, 76, 70, 3, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('David', 'Silva', 11, 0, 32, 72, 4, 2)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Diego', 'Costa', 9, 0, 40, 82, 4, 2)");

            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Matthew', 'Ryan', 1, 79, 0, 0, 1, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Jason', 'Davidson', 2, 0, 60, 49, 2, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Ryan', 'McGowan', 3, 0, 70, 48, 2, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Alex', 'Wilkinson', 4, 0, 70, 47, 2, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Matthew', 'Spiranovic', 7, 0, 30, 71, 2, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Matt', 'McKay', 5, 0, 56, 56, 3, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Mile', 'Jedinak', 8, 0, 77, 68, 3, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Mark', 'Bresciano', 14, 0, 55, 66, 3, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Tommy', 'Oar', 25, 0, 33, 60, 3, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Tim', 'Cahill', 11, 0, 50, 68, 4, 3)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Matthew', 'Leckie', 9, 0, 26, 69, 4, 3)");

            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Claudio', 'Bravo', 1, 84, 0, 0, 1, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Eugenio', 'Mena', 2, 0, 72, 48, 2, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Gary', 'Medel', 3, 0, 80, 48, 2, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Gonzalo', 'Jara', 4, 0, 74, 47, 2, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Charles', 'Aranguiz', 7, 0, 56, 71, 2, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Marcelo', 'Diaz', 5, 0, 75, 66, 3, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Mauricio', 'Isla', 8, 0, 59, 73, 3, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Francisco', 'Silva', 14, 0, 65, 65, 3, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Felipe', 'Gutierrez', 25, 0, 60, 68, 3, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Alexis', 'Sanchez', 11, 0, 39, 82, 4, 4)");
            Sql("INSERT INTO Player(Name, LastName, ShirtNumber, GkRating, DefRating, FwdRating, Position_Id, Team_Id) VALUES('Eduardo', 'Vargas', 9, 0, 32, 76, 4, 4)");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM Player WHERE Id IN (1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44");
        }
    }
}
