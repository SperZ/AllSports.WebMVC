using AllSports.Data;
using AllSports.Models.LeagueModels;
using AllSports.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class TeamService
    {
        private readonly string _userName;
        public TeamService(string userName)
        {
            _userName = userName;
        }

        public bool CreateTeam(TeamCreate model)
        {
            //byte[] bytes = null;
            //if (model.File != null)
            //{
            //    Stream fileStream = model.File.InputStream;
            //    BinaryReader reader = new BinaryReader(fileStream);
            //    bytes = reader.ReadBytes((Int32)fileStream.Length);
            //}
            var entity =
                new Team()
                {
                    LeagueId = model.LeagueId,
                    TeamName = model.TeamName,
                    CityName = model.CityName,
                    State = model.State,
                    Wins = model.Wins,
                    Losses = model.Losses,
                    //Contents = bytes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Teams.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeams()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allTeams =
                    ctx
                    .Teams
                    .Select
                    (
                        e =>
                        new TeamListItem
                        {
                            TeamId = e.TeamId,
                            TeamName = e.TeamName,
                            SportName = e.League.Sport.SportName,
                            LeagueName = e.League.LeagueName
                        }

                        );
                return allTeams.ToArray().OrderBy(e => e.TeamId);
            }
        }

        public IEnumerable<Team> GetTeamsData()
        {
            using(var ctx = new ApplicationDbContext())
            {
                return ctx.Teams.ToList();
            }
        }
        public TeamDetail GetTeamById(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId);
                return
                    new TeamDetail
                    {
                        TeamId = entity.TeamId,
                        TeamName = entity.TeamName,
                        Wins = entity.Wins,
                        Losses = entity.Losses,
                        CityName = entity.CityName,
                        State = entity.State,
                        //CostOfTeam = GetAllPlayersSalary(teamId),
                        LeagueName = entity.League.LeagueName,
                        //Contents = entity.Contents
                       
                    };
            }
        }

        public IEnumerable<League_Team_ListItem> GetTeamsbyLeagueId(int LeagueId)// not added to controller
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allteams =
                    ctx
                    .Leagues
                    .Single(e => e.LeagueId == LeagueId)
                    .Teams
                    .Select
                    (
                        e =>
                        new League_Team_ListItem
                        {
                            TeamId = e.TeamId,
                            TeamName = e.TeamName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            CityName = e.CityName,
                            State = e.State
                        }

                        );
                return allteams.ToArray().OrderBy(e => e.TeamName);

            }
        }

        public bool UpdateTeam(TeamEdit model) // not added to controller
        {
            //Stream fileStream = model.File.InputStream;
            //BinaryReader reader = new BinaryReader(fileStream);
            //byte[] bytes = reader.ReadBytes((Int32)fileStream.Length);
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId);
                entity.TeamName = model.TeamName;
                entity.Wins = model.Wins;
                entity.Losses = model.Losses;
                entity.CityName = model.CityName;
                entity.State = model.State;
                //entity.Contents = model.Contents;
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TeamListItem> GetTeamsByFanId(int fanId)// not added to controller
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allteams =
                    ctx
                    .Fans
                    .Single(e => e.FanId == fanId)
                    .Teams
                    .Select(
                        e =>
                        new TeamListItem()
                        {
                            TeamId = e.TeamId,
                            TeamName = e.TeamName,
                        }
                        );
                return allteams.ToArray();
            }
        }

        //public int GetAllPlayersSalary(int teamId)
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        var team =
        //            ctx
        //            .Teams
        //            .Single(e => e.TeamId == teamId)
        //            .Players;
        //        int total = 0;
        //        foreach (var player in team)
        //        {
        //            int salary = player.Salary;
        //            total += salary;
        //        }
        //        return total;
        //    }
        //}

        public bool Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == id);

                ctx.Teams.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
