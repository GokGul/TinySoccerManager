using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TinySoccerManager.DAL;
using TinySoccerManager.Models;

namespace TinySoccerManager.Controllers
{
    public class GameController : Controller
    {
        private SoccerContext context;
        public GameController()
        {
            //Database context initialiseren (en entiteiten mappen (Entity Framework, code-first)
            //Er is verder ook gebruik gemaakt van code-first migrations
            context = new SoccerContext();
        }
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {
            //Hier wordt een lijst aangemaakt die alleen het type Team accepteert
            //Vervolgens worden de teams uit de database opgehaald en in een lijstje gepropt.
            List<Team> t = new List<Team>();
            t = context.Teams.ToList();

            Queue<Team> matchups = TeamMatchUps(t);

            List<Game> games = new List<Game>();
            Dictionary<Team, int> PouleResults = new Dictionary<Team, int>();

            //Poule is voor nu nog statisch, want de opdracht is om wedstrijden te simuleren
            Poule p = new Poule
            {
                Name = "E",
                PouleResults = PouleResults
            };

            for (int i = 0; i < (t.Count * 1.5); i++)
            {
                //Hier wordt een game aangemaakt in een for-loop, de team.count * 1.5 zorgt ervoor dat alle mogelijke match-ups worden bereikt
                var game = new Game
                {
                    Home = matchups.Dequeue(),
                    Away = matchups.Dequeue(),
                    Date = DateTime.Now,
                    Poule = p
                };

                //Hieronder voegen we de games toe aan een lijst en sturen die door naar de view
                games.Add(game);
                game.simGame();
                    
                //Hieronder worden de games toegevoegd aan de entiteit in de database context en vervolgens worden ze opgeslagen in de database
                context.Games.Add(game);
                context.SaveChanges();
            }
            ViewBag.results = PouleResults;

            return View(games);
        }

        private Queue<Team> TeamMatchUps(List<Team> teams)
        {
            //In deze methode worden de teams aan elkaar gematched
            //In de eerste for-loop wordt een team gepakt, daarna wordt er in de tweede for-loop gecontroleerd of er niet weer dezelfde team wordt gepakt als tegenstander
            //Zo krijg je altijd een match-up met twee verschillende teams
            //Er zijn inderdaad betere manieren om dit op te lossen (bijv: met een key/value pair), maar omdat dit een assessment is
            //heb ik voor een queue gekozen om te laten zien dat ik deze functie ken

            Queue<Team> matchUps = new Queue<Team>();
            for (int i = 1; i < teams.Count; i++)
            {
                for (int y = 0; y < teams.Count; y++)
                {
                    if (i != y && y < i)
                    {
                        matchUps.Enqueue(teams[i]);
                        matchUps.Enqueue(teams[y]);
                    }
                }
            }
            return matchUps;
        }

        public ActionResult Details(int id)
        {
            //Hieronder wordt eerst een game in de database gezocht op id en vervolgens een lijst met GameResult objecten opgehaald met LINQ
            Game g = context.Games.Find(id);
            IEnumerable<GameResult> results = context.GameResults.Where(x => x.Game.Id == id).ToList();

            return View(results);
        }
    }
}