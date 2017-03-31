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

        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Poule> Poules { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<GameResult> GameResults { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}