using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SoccerLeague.Models;

namespace SoccerLeague.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        public ActionResult Index()
        {
            //declare variables
            List<SoccerTeam> lstTeams = new List<SoccerTeam>();
            List<SoccerTeam> lstSorted;
            int iTeamRank = 0;

            //Load the data
            lstTeams.Add(new SoccerTeam("RSL", 35, "https://www.rsl.com"));
            lstTeams.Add(new SoccerTeam("Colorado", 24, "https://www.coloradorapids.com"));
            lstTeams.Add(new SoccerTeam("FC Dallas", 42, "https://www.fcdallas.com"));
            lstTeams.Add(new SoccerTeam("Sporting KC", 39, "https://www.sportingkc.com"));
            lstTeams.Add(new SoccerTeam("San Jose", 16, "https://www.sjearthquakes.com"));
            lstTeams.Add(new SoccerTeam("Houston", 27, "https://www.houstondynamo.com"));
            lstTeams.Add(new SoccerTeam("Seattle", 32, "https://www.soundersfc.com"));
            lstTeams.Add(new SoccerTeam("Vancouver", 33, "https://www.whitecapsfc.com"));
            lstTeams.Add(new SoccerTeam("Minnesota", 29, "https://www.mnufc.com"));
            lstTeams.Add(new SoccerTeam("Portland", 37, "https://www.timbers.com"));
            lstTeams.Add(new SoccerTeam("LA Galaxy", 37, "https://www.lagalaxy.com"));
            lstTeams.Add(new SoccerTeam("LAFC", 39, "https://www.lafc.com"));

            //Sort the list
            lstSorted = lstTeams.OrderByDescending(x => x.points).ToList();

            ViewBag.Output += "<table class=\"table table-striped table-hover\" style=\"background-color: #fff\">";
            ViewBag.Output += "<thead class=\"thead-dark\">";
            ViewBag.Output += "<tr>";
            ViewBag.Output += "<th>Ranking</th>";
            ViewBag.Output += "<th>Team Name</th>";
            ViewBag.Output += "<th>Points</th>";
            ViewBag.Output += "</tr>";
            ViewBag.Output += "</thead>";

            ViewBag.Output += "<tbody id=\"myTable\">";

            foreach (SoccerTeam myObj in lstSorted)
            {
                iTeamRank++;
                ViewBag.Output += "<tr>";
                ViewBag.Output += "<td>" + iTeamRank + "</td>";
                ViewBag.Output += "<td>" + "<img src=\"../../Images/Icons/" + myObj.name + ".ico\" style=\"width: 30px\" class=\"team-images\"/> &nbsp;" + "<a href=\"" + myObj.webAddress + "\">" + myObj.name + "</a></td>";
                ViewBag.Output += "<td>" + myObj.points + "</td>";
                ViewBag.Output += "</tr>";
            }

            ViewBag.output += "</tbody>";
            ViewBag.output += "</table>";

            return View();
        }
    }
}