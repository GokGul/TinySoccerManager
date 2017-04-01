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

        internal void simGame()
        {
            int homeScore = 0;
            int awayScore = 0;

            int homeOffence = calculateOffence(this.Home.Players);
            int homeDefence = calculateDefence(this.Home.Players);

            int awayOffence = calculateOffence(this.Away.Players);
            int awayDefence = calculateOffence(this.Away.Players);

            int homePercentage = homeOffence / (homeOffence + awayDefence) * 100 /2;
            int awayPercentage = awayOffence / (awayOffence + homeDefence) * 100 /2;

            Random r = new Random();            

            for (int i = 0; i < 90; i++)
            {
                int eventNumber = r.Next(100);

                if (eventNumber <= homePercentage)
                {
                    homeScore++;
                } else if(homePercentage < eventNumber && eventNumber <= awayPercentage)
                {
                    awayScore++;
                }
                else
                {
                    //Er gebeurt niets.
                }
            }

            this.Result = String.Format("{0}-{1}", homeScore, awayScore);
        }

        private int calculateOffence(ICollection<Player> players)
        {
            int offence = 0;

            foreach (Player p in players)
            {
                offence += p.FwdRating;
            }
            return offence;
        }

        private int calculateDefence(ICollection<Player> players)
        {
            int defence = 0;

            foreach (Player p in players)
            {
                defence += p.DefRating;
            }
            return defence;
        }
    }
}