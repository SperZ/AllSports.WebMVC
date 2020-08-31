using AllSports.Data;
using AllSports.Models.FanModels;
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
    public class FanController : Controller
    {
        public FanService CreateFanService()
        {
            var userName = User.Identity.GetUserName();
            var service = new FanService(userName);
            return service;
        }
        // GET: Fan
        public ActionResult Index()
        {
            var service = CreateFanService();
            var model = service.GetFans();

            return View(model);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FanCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFanService();

            if (service.CreateFan(model))
            {
                TempData["SaveResult"] = $"The Fan {model.FirstName} {model.LastName} was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"The fan {model.FirstName} {model.LastName} was not created.");

            return View(model);
        }
        [Route("Fan/ConnectFanWithTeam/id")]
        public ActionResult ConnectFanWithTeam(string userName)
        {
            List<Team> Teams = (new TeamService(userName)).GetTeamsData().ToList();
            var query = from T in Teams
                        select new SelectListItem()
                        {
                            Value = T.TeamId.ToString(),
                            Text = T.TeamName
                        };
            ViewBag.TeamId = query.ToList();
            return View();
        }

        [HttpPost]
        [ActionName("ConnectFanWithTeam")]// this must match the name of the method that returns the view
        [ValidateAntiForgeryToken]
        public ActionResult Connect(int id, ConnectFan model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFanService();
           

            if (service.ConnectFanToTeam(id, model))
            {
                TempData["SaveResult"] = $"You are now a fan of {model.TeamId}";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The model could not be connected.");

            return View(model);
        }

        [HttpGet, Route("Fan/FanList/id")]
        public ActionResult FanList(int id)
        {
            var service = CreateFanService();
            var model = service.GetFansByTeamId(id);
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateFanService();
            var model = service.GetFanbyId(id);

            return View(model)
;
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFanService();
            var details = service.GetFanbyId(id);
            var model =
                new FanEdit
                {
                    FanId = details.FanId,
                    FirstName = details.FirstName,
                    LastName = details.LastName,
                    CityName = details.CityName,
                    State = details.State
                };

            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateFan(FanEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFanService();
            if (service.UpdateFan(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName}s' information has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"Unable to update {model.FirstName} {model.LastName}s' information.");

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateFanService();
            var model = service.GetFanbyId(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteTeam(int id)
        {
            var service = CreateFanService();
            var model = service.GetFanbyId(id);
            service.Delete(id);
            TempData["SaveResult"] = $"{model.FirstName} {model.LastName} has been deleted.";

            return RedirectToAction("Index");
        }
    }
}