using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();
            return View();
        }

        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.WomensLeagues = _context.Leagues
            .Where(l => l.Name.Contains("Women"))
            .ToList();

            ViewBag.NotFootball = _context.Leagues
            .Where(l => l.Sport != ("Football"))
            .ToList();

            ViewBag.IsHockey = _context.Leagues
            .Where(l => l.Name.Contains("Hockey") || l.Sport.Contains("Hockey"))
            .ToList();

            ViewBag.Conference = _context.Leagues
            .Where(l => l.Name.Contains("Conference"))
            .ToList();

            ViewBag.Atlantic = _context.Leagues
            .Where(l => l.Name.Contains("Atlantic"))
            .ToList();

            ViewBag.Dallas = _context.Teams
            .Where(t => t.Location.Contains("Dallas") || t.TeamName.Contains("Dallas"))
            .ToList();

            ViewBag.Raptors = _context.Teams
            .Where(t => t.TeamName.Contains("Raptors"))
            .ToList();

            ViewBag.City = _context.Teams
            .Where(t => t.Location.Contains("City"))
            .ToList();

            ViewBag.TName = _context.Teams
            .Where(t => t.TeamName.StartsWith("T"))
            .ToList();

            ViewBag.TeamsABC = _context.Teams
            .OrderBy(t => t.Location)
            .ToList();

            ViewBag.TeamsZYX = _context.Teams
            .OrderByDescending(t => t.TeamName)
            .ToList();

            ViewBag.Cooper = _context.Players
            .Where(t => t.LastName.Contains("Cooper"))
            .ToList();

            ViewBag.Joshua = _context.Players
            .Where(t => t.FirstName.Contains("Joshua"))
            .ToList();

            ViewBag.CoopNotJosh = _context.Players
            .Where(t => t.LastName.Contains("Cooper") && t.FirstName != "Joshua")
            .ToList();

            ViewBag.AlexWyatt = _context.Players
            .Where(t => t.FirstName == "Alexander" || t.FirstName == "Wyatt")
            .ToList();
            return View();

        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}