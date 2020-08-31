﻿using AllSports.Models.CoachModels;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CoachCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateCoachService();

            if (service.CreateCoach(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName} was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", $"{model.FirstName} {model.LastName} could not be created.");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachById(id);
            return View(model);
        }
        [HttpGet, Route("Coach/CoachList/id")]
        public ActionResult CoachList(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachesbyTeamId(id);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateCoachService();
            var detail = service.GetCoachById(id);
            var model =
                new CoachEdit
                {
                    CoachId = detail.CoachId,
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    YearsWithTeam = detail.YearsWithTeam,
                    CoachPosition = detail.CoachPosition,
                    TeamId = detail.TeamId
                };

            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, CoachEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.CoachId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreateCoachService();
            if (service.UpdateCoach(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName}s' information has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"Unable to update {model.FirstName} {model.LastName}s' information.");
            return View();
        }


        public ActionResult Delete(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteCoach(int id)
        {
            var service = CreateCoachService();
            var model = service.GetCoachById(id);
            service.Delete(id);
            TempData["SaveResult"] = $"{model.FirstName} {model.LastName} has been deleted";

            return RedirectToAction("Index");
        }
    }
}