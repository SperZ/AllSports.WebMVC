using AllSports.Data;
using AllSports.Models.TeamModels;
using AllSports.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllSports.WebMVC.Controllers
{
    [Authorize]
    public class TeamController : Controller
    {
        public TeamService CreateTeamService()
        {
            var userName = User.Identity.GetUserName();
            var service = new TeamService(userName);
            return service;
        }
        // GET: League
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = CreateTeamService();
            var model = service.GetTeams();
            return View(model);
        }

        public ActionResult Create(string username)
        {

            List<League> Leagues = (new LeagueService(username)).GetLeaguesData().ToList();
            var query = from l in Leagues
                        select new SelectListItem()
                        { Value = l.LeagueId.ToString(),
                            Text = l.LeagueName
                        };
            ViewBag.LeagueId = query.ToList();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TeamCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeamService();

            if (service.CreateTeam(model))
            {
                TempData["Save Result"] = $"{model.TeamName} was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.TeamName} could not be created");

            return View(model);
        }

        [HttpGet, Route("Team/GetTeamsByLeague/id")]
        [AllowAnonymous]
        public ActionResult GetTeamsByLeague(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamsbyLeagueId(id);
            return View(model);

        }


        [HttpGet, Route("Team/TeamList/id")]
        [AllowAnonymous]
        public ActionResult TeamList(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamsByFanId(id);
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateTeamService();
            var detail = service.GetTeamById(id);
            var model =
                new TeamEdit
                {
                    TeamId = detail.TeamId,
                    TeamName = detail.TeamName,
                    Wins = detail.Wins,
                    Losses = detail.Losses,
                    CityName = detail.CityName,
                    State = detail.State
                };
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateTeam(TeamEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateTeamService();

            if (service.UpdateTeam(model))
            {
                TempData["SaveResult"] = $"The {model.TeamName} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"Unable to update the {model.TeamName}");
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteTeam(int id)
        {
            var service = CreateTeamService();
            var model = service.GetTeamById(id);
            service.Delete(id);
            TempData["SaveResult"] = $"{model.TeamName} has been deleted.";

            return RedirectToAction("Index");
        }
    }
}