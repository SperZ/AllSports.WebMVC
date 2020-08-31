using AllSports.Data;
using AllSports.Models.LeagueModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class LeagueService
    {
        public readonly string _userName;
        public LeagueService(string userName)
        {
            _userName = userName;
        }

        public bool CreateLeague(LeagueCreate model)
        {
            var entity =
                new League()
                {
                    LeagueName= model.LeagueName,
                    LeagueInception = model.LeagueInception,
                    NumberOfTeams = model.NumberOfTeams,
                    BaseCountry = model.BaseCountry,
                    SportId = model.SportId 
                };
            using(var ctx = new ApplicationDbContext())
            {
                ctx.Leagues.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<LeagueListItem> GetLeagues()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allLeagues =
                    ctx
                    .Leagues
                    .Select(
                        e =>
                        new LeagueListItem
                        {
                            LeagueId = e.LeagueId,
                            LeagueName = e.LeagueName,
                        }

                        );
                return allLeagues.ToArray();
            }
        }

        public IEnumerable<League> GetLeaguesData()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Leagues.ToList();
            }
        }

        public LeagueDetail GetLeagueById(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Leagues
                    .Single(e => e.LeagueId == id);
                return
                    new LeagueDetail
                    {
                        LeagueId = entity.LeagueId,
                        LeagueName = entity.LeagueName,
                        LeagueInception = entity.LeagueInception,
                        NumberOfTeams = entity.NumberOfTeams,
                        BaseCountry = entity.BaseCountry,
                        SportName = entity.Sport.SportName
                    };
            }
        }

        public bool UpdateLeague(LeagueEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Leagues
                    .Single(e => e.LeagueId == model.LeagueId);
                entity.NumberOfTeams = model.NumberOfTeams;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int id)
        {
            using( var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Leagues
                    .Single(e => e.LeagueId == id);

                ctx.Leagues.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
