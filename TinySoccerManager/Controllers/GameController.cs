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
            context = new SoccerContext();
        }
        // GET: Game
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Play()
        {
            List<Team> t = new List<Team>();
            t = context.Teams.ToList();

            Queue<Team> matchups = TeamMatchUps(context.Teams.ToList());

            List<Game> games = new List<Game>();

            for (int i = 0; i < (t.Count * 1.5); i++)
            {
                var game = new Game
                {
                    Home = matchups.Dequeue(),
                    Away = matchups.Dequeue(),
                    Date = DateTime.Now,
                    Result = simGame()
                };
                games.Add(game);

                context.Games.Add(game);
                context.SaveChanges();
            }

            return View(games);
        }

        private Queue<Team> TeamMatchUps(List<Team> teams)
        {
            Queue<Team> matchUps = new Queue<Team>();
            for (int i = 0; i < teams.Count; i++)
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

        private string simGame()
        {
            string result = "3-2";

            return result;
        }
    }
}