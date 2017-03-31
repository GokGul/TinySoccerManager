using System.Collections.Generic;

namespace TinySoccerManager.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int ShirtNumber { get; set; }
        public int GkRating { get; set; }
        public int DefRating { get; set; }
        public int FwdRating { get; set; }
        public virtual Position Position { get; set; }
        public virtual Team Team { get; set; }
        public virtual ICollection<GameResult> GameResults { get; set; }
    }
}