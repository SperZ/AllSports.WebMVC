using AllSports.Data;
using AllSports.Models.CoachModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class CoachService
    {
        private readonly string _userName;
        public CoachService(string userName)
        {
            _userName = userName;
        }

        public bool CreateCoach(CoachCreate model)
        {
            var coach =
                new Coach()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    CoachPosition = model.CoachPosition,
                    TeamId = model.TeamId,
                    YearsWithTeam = model.YearsWithTeam,
                    College = model.College
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Coaches.Add(coach);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CoachListItem> GetCoaches()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allcoaches =
                    ctx
                    .Coaches
                    .Select(
                        e =>
                        new CoachListItem()
                        {
                            CoachId = e.CoachId,
                            FirstName = e.FirstName,
                            LastName = e.LastName
                        }
                        );
                return allcoaches.ToArray();
            }
        }

        public IEnumerable<Team_CoachListItem> GetCoachesbyTeamId(int teamId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allcoaches =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId)
                    .Coaches
                    .Select(
                        e =>
                        new Team_CoachListItem()
                        {
                            CoachId = e.CoachId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            CoachPosition = e.CoachPosition,
                            YearsWithTeam = e.YearsWithTeam,
                        }

                        );
                return allcoaches.ToArray();
            }
        }

        public CoachDetail GetCoachById(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var coach =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == id);
                return
                    new CoachDetail()
                    {
                        FirstName = coach.FirstName,
                        LastName = coach.LastName,
                        TeamName = coach.Team.TeamName,
                        CoachPosition = coach.CoachPosition,
                        YearsWithTeam = coach.YearsWithTeam,
                        College = coach.College,
                    };
            }
        }

        public bool UpdateCoach(CoachEdit model) // not added to controller
        {
            using(var ctx = new ApplicationDbContext())
            {
                var updates =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == model.CoachId);
                updates.FirstName = model.FirstName;
                updates.LastName = model.LastName;
                updates.CoachPosition = model.CoachPosition;
                updates.YearsWithTeam = model.YearsWithTeam;
                updates.TeamId = model.TeamId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Coaches
                    .Single(e => e.CoachId == id);

                ctx.Coaches.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
