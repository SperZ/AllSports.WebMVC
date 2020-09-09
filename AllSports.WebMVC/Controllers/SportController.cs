using AllSports.Models.SportModels;
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
    public class SportController : Controller
    {
        public SportService CreateSportService()
        {
            var userName = User.Identity.GetUserName();
            var service = new SportService(userName);
            return service;
        }
        // GET: Sport
        [AllowAnonymous]
        public ActionResult Index()
        {
            SportService sportService = CreateSportService();
            var model = sportService.GetSports();
            return View(model);
        }

        //Get: SportsCreate View
        public ActionResult Create()
        {
            return View();
        }

        //Post: Sport
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SportCreate model)
        {
            if (!ModelState.IsValid) return View(model);


            var service = CreateSportService();

            if (service.CreateSport(model))
            {
                TempData["SaveResult"] = $"{model.SportName} has been Created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"{model.SportName} could not be created");

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = CreateSportService();
            var model = service.GetSportbyId(id);

            return View(model);
        }

        //Get Delete View
        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var service = CreateSportService();
            var model = service.GetSportbyId(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSport(int id)
        {
            var service = CreateSportService();
            var model = service.GetSportbyId(id);
            service.Delete(id);
            TempData["SaveResult"] = $"{model.SportName} has been deleted.";

            return RedirectToAction("Index");
        }
    }
}