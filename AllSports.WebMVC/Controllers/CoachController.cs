using AllSports.Models.CoachModels;
using AllSports.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllSports.WebMVC.Controllers
{
    public class CoachController : Controller
    {
        public CoachService CreateCoachService()
        {
            var userName = User.Identity.GetUserName();
            var service = new CoachService(userName);

            return service;
        }
        // GET: Coach
        public ActionResult Index()
        {
            var service = CreateCoachService();
            var model = service.GetCoaches();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult CreateCoach(CoachCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCoachService();

            if (service.Create(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName} has been created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.FirstName} {model.LastName} was not created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachById(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachById(id);
            return View(model);
        }

        public ActionResult DeleteCoach(int id)
        {
            var service = CreateCoachService();
            service.Delete(id);
            var model = service.GetCoachById(id);
            TempData["SaveResult"] = $"{model.FirstName} {model.LastName} has been deleted";

            return RedirectToAction("Index");
        }
    }
}