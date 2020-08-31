using AllSports.Data;
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

        public ActionResult Create(string userName)
        {
            List<Team> Teams = (new TeamService(userName)).GetTeamsData().ToList();
            var query = from T in Teams
                        select new SelectListItem()
                        {
                            Value = T.TeamId.ToString(),
                            Text=T.TeamName
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

        public ActionResult Details(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayerById(id);

            return View(model);
        }

        [HttpGet, Route("Player/List/id")]
        public ActionResult List(int id)
        {
            var service = CreatePlayerService();
            var model = service.GetPlayersbyTeamId(id);
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreatePlayerService();
            var detail = service.GetPlayerById(id);
            var model =
                new PlayerEdit 
                {
                    PlayerId = detail.PlayerId,
                    FirstName= detail.FirstName,
                    LastName= detail.LastName,
                    JerseyNumber = detail.JerseyNumber,
                    Height = detail.Height,
                    Weight= detail.Weight,
                    YearsWithTeam = detail.YearsWithTeam,
                    TwitterHandle = detail.TwitterHandle,
                    TeamId = detail.TeamId
                };

            return View(model);
        } 

        [HttpPost]
        [ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PlayerEdit model) 
        {
            if (!ModelState.IsValid) return View(model);

            if(model.PlayerId != id)
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