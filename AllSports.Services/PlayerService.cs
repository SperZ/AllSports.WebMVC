using AllSports.Data;
using AllSports.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class PlayerService
    {
        private readonly string _userName;
        public PlayerService(string userName)
        {
            _userName = userName;
        }

        public bool Create(PlayerCreate model)
        {
            var player =
                new Player()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    DateOfBirth = model.DateOfBirth,
                    JerseyNumber = model.JerseyNumber,
                    Height = model.Height,
                    Weight = model.Weight,
                    College = model.College,
                    TwitterHandle = model.TwitterHandle,
                    TeamId = model.TeamId,
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Players.Add(player);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PlayerListItem> GetPlayers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allplayers =
                    ctx
                    .Players
                    .Select
                    (
                        e =>
                        new PlayerListItem
                        {
                            PlayerId = e.PlayerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Age = e.Age,
                            TeamName = e.Team.TeamName,
                            JerseyNumber = e.JerseyNumber,

                        }
                        );
                return allplayers.ToArray();
            }

        }

        public PlayerDetail GetPlayerById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == id);
                return
                    new PlayerDetail()
                    {
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Age = player.Age,
                        DateOfBirth = player.DateOfBirth,
                        Height = player.Height,
                        Weight = player.Weight,
                        JerseyNumber = player.JerseyNumber,
                        TeamName = player.Team.TeamName,

                        College = player.College,
                        TwitterHandle = player.TwitterHandle,
                    };
            }
        }

        public IEnumerable<Team_PlayerListItem> GetPlayersbyTeamId(int teamId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var allplayers =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId)
                    .Players
                    .Select
                    (
                        e =>
                        new Team_PlayerListItem
                        {
                            PlayerId = e.PlayerId,
                            FirstName = e.FirstName,
                            LastName = e.LastName,
                            Age = e.Age,
                            JerseyNumber = e.JerseyNumber,
                            YearsWithTeam = e.YearsWithTeam,
                            College = e.College,
                        }

                        );
                return allplayers.ToArray();
            }
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var updates =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == model.PlayerId);
                updates.FirstName = model.FirstName;
                updates.LastName = model.LastName;
                updates.DateOfBirth = model.DateOfBirth;
                updates.Height = model.Height;
                updates.JerseyNumber = model.JerseyNumber;
                updates.TeamId = model.TeamId;
                updates.TwitterHandle = model.TwitterHandle;

                return ctx.SaveChanges() == 1;


            }
        }
    }
}

