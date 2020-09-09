using AllSports.Data;
using AllSports.Models.StoryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class StoryService
    {
        private readonly string _userName;
        public StoryService(string userName)
        {
            _userName = userName;
        }

        public bool CreateStory(StoryCreate model)
        {
            var entity =
                new Story()
                {
                    HeadLine = model.HeadLine,
                    Content = model.Content,
                    PlayerId = model.PlayerId,
                    CreatedUTC = DateTimeOffset.Now,
                    UserName= _userName
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Stories.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<StoryListItem> GetStories()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allStories =
                    ctx
                    .Stories
                    .Select
                    (
                        e =>
                        new StoryListItem
                        {
                            StoryId = e.StoryId,
                            HeadLine = e.HeadLine,
                            FirstName= e.Player.FirstName,
                            LastName = e.Player.LastName,
                            CreatedUtc = e.CreatedUTC
                        }

                        );
                return allStories.ToArray();
            }
        }

        public StoryDetail GetStoryById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var details =
                    ctx
                    .Stories
                    .Single(e => e.StoryId == id);
                return new StoryDetail()
                {
                    HeadLine = details.HeadLine,
                    FirstName = details.Player.FirstName,
                    LastName = details.Player.LastName,
                    TeamName = details.Player.Team.TeamName,
                    Content= details.Content,
                    CreatedUtc=details.CreatedUTC,
                    UserName=details.UserName
                };
            }
        }

        public bool DeleteStory(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var story =
                    ctx
                    .Stories
                    .Where(e => e.UserName == _userName)
                    .Single(e => e.StoryId == id);
                ctx.Stories.Remove(story);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
