using AllSports.Data;
using AllSports.Models.StoryModels;
using AllSports.Services;
using Microsoft.AspNet.Identity;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AllSports.WebMVC.Controllers
{
    [Authorize]
    public class StoryController : Controller
    {
        public StoryService CreateStoryService()
        {
            var userName = User.Identity.GetUserName();
            var service = new StoryService(userName);
            return service;
        }
        // GET: Story
        public ActionResult Index()
        {
            var service = CreateStoryService();
            var model = service.GetStories();
            return View(model);
        }

        public ActionResult Create(string userName) 
        {
            List<Player> players = (new PlayerService(userName)).GetPlayersData().ToList();
            var query = from P in players
                        select new SelectListItem()
                        {
                            Value = P.PlayerId.ToString(),
                            Text= P.FullName
                        };
            ViewBag.PlayerId = query.ToList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StoryCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateStoryService();

            if (service.CreateStory(model))
            {
                TempData["SaveResult"] = $"The story {model.HeadLine} has been created";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "The story was not created");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = CreateStoryService();
            var model = service.GetStoryById(id);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var service = CreateStoryService();
            var model = service.GetStoryById(id);
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteStory(int id) 
        {
            var service = CreateStoryService();
            var model = service.GetStoryById(id);
            service.DeleteStory(id);

            TempData["SaveResult"] = $"{model.HeadLine} was deleted.";

            return RedirectToAction("Index");

        }

    }
}