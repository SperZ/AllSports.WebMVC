using AllSports.Data;
using AllSports.Models.LeagueModels;
using AllSports.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllSports.WebMVC.Controllers
{
    [Authorize(Roles ="admin")]   
    public class LeagueController : Controller
    {
        [Authorize]
        public LeagueService CreateLeagueService()
        {
            var userName = User.Identity.GetUserName();
            var service = new LeagueService(userName);
            return service;
        }

        // GET: League
        [AllowAnonymous]
        public ActionResult Index()
        {
            var service = CreateLeagueService();
            var model = service.GetLeagues();
            return View(model);
        }

        public ActionResult Create(string userName)
        {
            List<Sport> Sports = (new SportService(userName)).GetSportsData().ToList();
            var query = from S in Sports
                        select new SelectListItem() 
                        { 
                            Value=S.SportId.ToString(),
                            Text=S.SportName
                        };
            ViewBag.SportId = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LeagueCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLeagueService();

            if (service.CreateLeague(model))
            {
                TempData["Save Result"] = $"{model.LeagueName} was created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.LeagueName} could not be created");

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = CreateLeagueService();
            var model = service.GetLeagueById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateLeagueService();
            var detail = service.GetLeagueById(id);
            var model =
                new LeagueEdit
                {
                    LeagueId = detail.LeagueId,
                    LeagueName = detail.LeagueName,
                    NumberOfTeams = detail.NumberOfTeams,
                    BaseCountry = detail.BaseCountry,
                };
            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateLeague(int id, LeagueEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateLeagueService();

            if (service.UpdateLeague(model))
            {
                TempData["SaveResult"] = $"{model.LeagueName} was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"Unable to update {model.LeagueName}");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateLeagueService();
            var model = service.GetLeagueById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteLeague(int id)
        {
            var service = CreateLeagueService();
            var model = service.GetLeagueById(id);
            service.Delete(id);
            TempData["SaveResult"] = $"{model.LeagueName} has been deleted.";

            return RedirectToAction("Index");
        }
    }
}