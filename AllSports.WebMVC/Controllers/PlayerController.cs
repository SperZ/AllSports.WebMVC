﻿using AllSports.Data;
using AllSports.Models.PlayerModels;
using AllSports.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllSports.WebMVC.Controllers
{
    public class PlayerController : Controller
    {
        [Authorize]
        public PlayerService CreatePlayerService()
        {
            var userName = User.Identity.GetUserName();
            var service = new PlayerService(userName);
            return service;
        }
        // GET: Player
        public ActionResult Index()
        {
            PlayerService service = CreatePlayerService();
            var model = service.GetPlayers();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePlayerService();

            if (service.CreatePlayer(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName} was created.";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", $"{model.FirstName} {model.LastName} could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayerById(id);

            return View(model);
        }
    }
}