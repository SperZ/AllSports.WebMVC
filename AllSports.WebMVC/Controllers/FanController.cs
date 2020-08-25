using AllSports.Models.FanModels;
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

        public ActionResult Details(int id)
        {
            var service = CreateFanService();
            var model = service.GetFanbyId(id);

            return View(model)
;
        }
    }
}