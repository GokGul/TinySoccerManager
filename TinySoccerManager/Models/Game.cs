using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TinySoccerManager.Models
{
    public class Game
    {
        public int Id { get; set; }
        public virtual Poule Poule { get; set; }
        public virtual Team Home { get; set; }
        public virtual Team Away { get; set; }
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Display(Name = "Resultaat")]
        public string Result { get; set; }

        public virtual ICollection<GameResult> GameResults { get; set; }

        internal void simGame()
        {
            int homeScore = 0;
            int awayScore = 0;

            //Dictionaries waarin spelers worden opgeslagen die een aanval stoppen of een goal scoren met het aantal.
            Dictionary<Player, int> stoppedOffences = new Dictionary<Player, int>();
            Dictionary<Player, int> createdGoals = new Dictionary<Player, int>();

            //Totale offensieve/defensieve ratings van alle spelers in het team van de thuis- en uitploegen.
            int homeOffence = calculateRating(Home, "offence");
            int homeDefence = calculateRating(Home, "defence");

            int awayOffence = calculateRating(Away, "offence");
            int awayDefence = calculateRating(Away, "defence");

            //Ik heb geprobeerd de wedstrijden te balanceren, vandaar deze formule.
            //Er wordt gekeken naar het totaal (thuis offensief - uit defensie) en daaruit ontstaat een percentage, oftewel de kanspercentage van de ploegen
            //Deze percentages worden nogmaals door 2 gedeeld, zodat de kans van beide teams bij elkaar niet boven de 50% komt.
            //In de overige 50% zijn er geen gebeurtenissen, oftwel de teams passen rustig heen en weer.
            double homePercentage = (double)homeOffence / (homeOffence + awayDefence) * 100 / 2;
            double awayPercentage = (double)awayOffence / (awayOffence + homeDefence) * 100 / 2;

            Random r = new Random();

            for (int i = 0; i < 90; i++)
            {
                //Hiermee worden er randoms gepakt om te bepalen of er een doelpoging komt of een verdedigende actie.
                int scoringOpportunity = r.Next(100);
                int defendingOpportunity = r.Next(100);

                Player p;

                //Als de doelpoging kleiner of gelijk is aan de thuis team kanspercentage, dan is het een kans voor de thuis team.
                if (scoringOpportunity <= homePercentage)
                {
                    //Is de verdedigingspercentage hoger of gelijk aan de thuis kanspercentage? dan pakt de verdediger de bal af.
                    if (defendingOpportunity >= homePercentage / 4)
                    {
                        p = actionBy(r, Away, "VER");
                        addToDict(stoppedOffences, p);

                    }
                    else
                    {
                        //Zo niet, dan wordt er gescoord.
                        p = actionBy(r, Home, "AAN");
                        addToDict(createdGoals, p);

                        homeScore++;
                    }
                }
                else if (scoringOpportunity <= (homePercentage + awayPercentage))
                {
                    if (defendingOpportunity >= homePercentage / 4)
                    {
                        p = actionBy(r, Home, "VER");
                        addToDict(stoppedOffences, p);

                    }
                    else
                    {
                        p = actionBy(r, Away, "AAN");
                        addToDict(createdGoals, p);

                        awayScore++;
                    }
                }
                else
                {
                    //Geen events.
                }
            }

            if (homeScore > awayScore)
            {
                calcPoints(Home, 3);
                calcPoints(Away, 0);
            }
            else if (awayScore > homeScore)
            {
                calcPoints(Away, 3);
                calcPoints(Home, 0);
            }else
            {
                calcPoints(Home, 1);
                calcPoints(Away, 1);
            }

            this.Result = String.Format("{0}-{1}", homeScore, awayScore);
            GameResults = createGameResults(stoppedOffences, createdGoals);
            SortPointsDict();            
        }

        private void SortPointsDict()
        {
            //Hier worden de punten gesorteerd
            //Met LINQ worden de pairs uit de dict gehaald en vervolgens in een nieuwe
            //dict gezet die wordt teruggegeven.
            var items = from pair in Poule.PouleResults
                        orderby pair.Value descending
                        select pair;

            Dictionary<Team, int> dict = new Dictionary<Team, int>();

            foreach (KeyValuePair<Team, int> pair in items)
            {
                dict.Add(pair.Key, pair.Value);
            }
            Poule.PouleResults = dict;
        }

        internal void calcPoints(Team curr, int pts)
        {
            //Hier worden de punten opgeteld.
            //Zit de team nog niet in de dict? dan wordt die met toegevoegd
            //En anders worden de bestaande punten met de nieuwe opgeteld
            if (Poule.PouleResults.ContainsKey(curr))
            {
                Poule.PouleResults[curr] += pts;
            }else
            {
                Poule.PouleResults.Add(curr, pts);
            }
        }

        private void addToDict(Dictionary<Player, int> dict, Player p)
        {
            if (dict.ContainsKey(p))
            {
                dict[p]++;
            }
            else
            {
                dict.Add(p, 1);
            }
        }

        private Player actionBy(Random r, Team currTeam, string type)
        {
            //Hier wordt berekend welke speler het doelpunt heeft gescoord of de aanval heeft gestopt.
            List<Player> list = new List<Player>();

            foreach (Player p in currTeam.Players)
            {
                if (p.Position.ShortName.Equals(type))
                {
                    list.Add(p);
                }
            }
            
            int randomPlayer = r.Next(list.Count);

            return list[randomPlayer];
        }

        private ICollection<GameResult> createGameResults(Dictionary<Player, int> stoppedOffences, Dictionary<Player, int> createdGoals)
        {
            //Hierin worden de spelresultaten opgeslagen in entiteiten die vervolgens naar de database worden gestuurd.
            List<GameResult> g = new List<GameResult>();
            foreach (KeyValuePair<Player, int> stoppers in stoppedOffences)
            {
                var gr = new GameResult
                {
                    Game = this,
                    Player = stoppers.Key,
                    OffenceStopped = stoppers.Value
                };
                g.Add(gr);
            }

            foreach (KeyValuePair<Player, int> scorers in createdGoals)
            {
                var gr = new GameResult
                {
                    Game = this,
                    Player = scorers.Key,
                    Goals = scorers.Value
                };
                g.Add(gr);
            }

            return g;
        }

        private int calculateRating(Team currTeam, string type)
        {
            //Hier worden de ratings van de teams berekend door de ratings van alle spelers op te tellen.
            //Offensief en defensie apart.
            int rating = 0;

            foreach (Player p in currTeam.Players)
            {
                if (type.Equals("offence"))
                {
                    rating += p.FwdRating;
                }
                else
                {
                    rating += p.DefRating;
                }
            }
            return rating;
        }
    }
}