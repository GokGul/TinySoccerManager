using System;
using System.Collections.Generic;

namespace TinySoccerManager.Models
{
    public class Game
    {
        public int Id { get; set; }
        public virtual Poule Poule { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }

        public virtual ICollection<GameResult> GameResults { get; set; }
    }
}