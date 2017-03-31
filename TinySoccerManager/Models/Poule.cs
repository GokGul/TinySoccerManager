using System.Collections.Generic;

namespace TinySoccerManager.Models
{
    public class Poule
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Tournament Tournament { get; set; }

        public virtual ICollection<Team> TeamsInPoule { get; set; }
        public virtual ICollection<Game> GamesInPoule { get; set; }
    }
}