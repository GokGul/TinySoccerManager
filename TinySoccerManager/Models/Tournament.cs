using System.Collections.Generic;

namespace TinySoccerManager.Models
{
    public class Tournament
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Poule> Poules { get; set; }
    }
}