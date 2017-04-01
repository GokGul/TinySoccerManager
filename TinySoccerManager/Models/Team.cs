using System.Collections.Generic;

namespace TinySoccerManager.Models
{
    public class Team
    {
        public int Id { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<Poule> Poule { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}