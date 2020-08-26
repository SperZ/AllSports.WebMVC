﻿using AllSports.Data;
using AllSports.Models.LeagueModels;
using AllSports.Models.TeamModels;
using System;
using System.Collections.Generic;
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
            var entity =
                new Team()
                {
                    LeagueId = model.LeagueId,
                    TeamName = model.TeamName,
                    CityName = model.CityName,
                    State = model.State,
                    Wins = model.Wins,
                    Losses = model.Losses,
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
                return allTeams.ToArray();
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
                        TeamName = entity.TeamName,
                        Wins = entity.Wins,
                        Losses = entity.Losses,
                        CityName = entity.CityName,
                        State = entity.State,
                        //CostOfTeam = GetAllPlayersSalary(teamId),
                        LeagueName = entity.League.LeagueName
                    };
            }
        }

        public IEnumerable<League_TeamListItem> GetTeamsbyLeagueId(int LeagueId)// not added to controller
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
                        new League_TeamListItem
                        {
                            TeamName = e.TeamName,
                            Wins = e.Wins,
                            Losses = e.Losses,
                            CityName = e.CityName,
                            State = e.State

                        }

                        );
                return allteams.ToArray();

            }
        }

        public bool UpdateTeam(TeamEdit model) // not added to controller
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId);
                entity.Wins = model.Wins;
                entity.Losses = model.Losses;
                entity.CityName = model.CityName;
                entity.State = model.State;

                return ctx.SaveChanges() == 1;
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
