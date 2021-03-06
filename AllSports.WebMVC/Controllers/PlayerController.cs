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
    [Authorize]
    public class PlayerController : Controller
    {
        public PlayerService CreatePlayerService()
        {
            var userName = User.Identity.GetUserName();
            var service = new PlayerService(userName);
            return service;
        }
        // GET: Player
        [AllowAnonymous]
        public ActionResult Index()
        {
            PlayerService service = CreatePlayerService();
            var model = service.GetPlayers();
            return View(model);
        }

        public ActionResult Create(string userName)
        {
            List<Team> teams = (new TeamService(userName)).GetTeamsData().ToList();
            var query = from T in teams
                        select new SelectListItem()
                        {
                            Value = T.TeamId.ToString(),
                            Text = T.TeamName
                        };
            ViewBag.TeamId = query.ToList();
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
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayerById(id);

            return View(model);
        }
        [AllowAnonymous]
        [HttpGet, Route("Player/List/id")]
        public ActionResult List(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayersbyTeamId(id);
            return View(model);
        }
        public ActionResult Edit(string userName, int id)
        {
            var player = CreatePlayerService().GetPlayerById(id);
            List<Team> teams = (new TeamService(userName)).GetTeamsData().ToList();
            ViewBag.TeamId = teams.Select(
                T => new SelectListItem()
                {
                    Value = T.TeamId.ToString(),
                    Text = T.TeamName,
                    Selected = player.TeamId == T.TeamId,
                });

            var model =
                new PlayerEdit
                {
                    PlayerId = player.PlayerId,
                    FirstName = player.FirstName,
                    LastName = player.LastName,
                    JerseyNumber = player.JerseyNumber,
                    Height = player.Height,
                    Weight = player.Weight,
                    YearsWithTeam = player.YearsWithTeam,
                    TwitterHandle = player.TwitterHandle,
                    TeamId = player.TeamId
                };

            return View(model);
        }

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PlayerId != id)
            {
                ModelState.AddModelError("", "Id mismatch");
                return View(model);
            }

            var service = CreatePlayerService();
            if (service.UpdatePlayer(model))
            {
                TempData["SaveResult"] = $"{model.FirstName} {model.LastName}s' information has been updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", $"Unable to update {model.FirstName} {model.LastName}s' information.");
            return View();
        }



        public ActionResult Delete(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayerById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeletePlayer(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayerById(id);
            service.Delete(id);

            TempData["SaveResult"] = $"{model.FirstName} {model.LastName} has been deleted.";

            return RedirectToAction("Index");

        }
    }
}