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
    public class TeamController : Controller
    {
        // GET: Team
        [Authorize]
        public TeamService CreateTeamService()
        {
            var userName = User.Identity.GetUserName();
            var service = new TeamService(userName);
            return service;
        }
        // GET: League
        public ActionResult Index()
        {
            var service = CreateTeamService();
            var list = service.GetTeams().ToList();
            var model = list.OrderBy(e => e.TeamId);
            return View(model);
        }

        public ActionResult Create()
        {
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
            TempData["SaveResult"] = $"{model.LeagueName} has been deleted.";

            return RedirectToAction("Index");
        }
    }
}