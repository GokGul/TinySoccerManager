using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TinySoccerManager.Models;

namespace TinySoccerManager.DAL
{
    public class SoccerContext : DbContext
    {
        public SoccerContext() : base("SoccerContext")
        {

        }

        //Hieronder maak ik verschillende entiteiten sets aan om ze te mappen
        //Hierdoor weet Entity Framework welke tabellen gecreerd moeten worden en aan welke modellen ze verbonden moeten zijn

        //Ik werk overigens met code-first migrations
        //Zoveel tijd had ik niet, dus ik heb maar een paar migrations voor een toch relatief grote database

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Poule> Poules { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        //Dit is een klein stukje Fluent API
        //Hieronder zeggen we eigenlijk dat het de standaard pluralization convention niet moet gebruiken, zodat de tabelnamen niet automatisch meervoud worden (Country en niet Countries)
        //Dit houdt in dat de modellen die ik heb aangemaakt, dezelfde namen behouden in de database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}