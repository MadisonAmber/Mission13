using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {
        private BowlingLeagueDbContext context { get; set; }

        public HomeController(BowlingLeagueDbContext ctx)
        {
            context = ctx;
        }

        public IActionResult Index(int teamid)
        {
            List<Bowler> bowlers = new List<Bowler>();
            if(teamid == 0)
            {
                ViewBag.Heading = "All Bowlers";
                bowlers = context.Bowlers
                    .Include(x => x.Team )
                    .ToList();
            } else
            {
                bowlers = context.Bowlers
                    .Where(x => x.TeamID == teamid)
                    .Include(x => x.Team)
                    .ToList();
                if(bowlers.Count > 0)
                {
                    ViewBag.Heading = "Team " + bowlers[0].Team.TeamName;
                    
                } else
                {
                    ViewBag.Heading = "No Bowlers Found For this Team.";
                }
            }

            ViewBag.SelectedTeam = teamid;

            List<Team> teams = context.Teams.ToList();
            ViewBag.Teams = teams;
            

            return View(bowlers);
        }

        [HttpGet]
        public IActionResult Edit(int bowlerid)
        {
            Bowler b = context.Bowlers
                .Include(x => x.Team)
                .Single(x => x.BowlerID == bowlerid);

            List<Team> teams = context.Teams.ToList();
            ViewBag.Teams = teams;

            return View(b);
        }

        [HttpGet]
        public IActionResult Add()
        {
            List<Team> teams = context.Teams.ToList();
            ViewBag.Teams = teams;

            Bowler b = new Bowler();

            return View("Edit", b);
        }

        [HttpPost]
        public IActionResult Add(Bowler b)
        {
            if(ModelState.IsValid)
            {
                if(b.BowlerID == 0)
                {
                    Bowler lastBowler = context.Bowlers.ToList().LastOrDefault();
                    b.BowlerID = lastBowler.BowlerID + 1;
                    context.Add(b);
                } else
                {
                    context.Update(b);
                }
                
                context.SaveChanges();
                return RedirectToAction("Index");
            } else
            {
                List<Team> teams = context.Teams.ToList();
                ViewBag.Teams = teams;
                return View("Edit", b);
            }
        }

        [HttpPost]
        public IActionResult Delete(Bowler b)
        {
            context.Bowlers.Remove(b);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}
