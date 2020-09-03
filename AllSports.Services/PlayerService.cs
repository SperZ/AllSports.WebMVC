using AllSports.Data;
using AllSports.Models.PlayerModels;
using System;
using System.Collections.Generic;
using System.IO;
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

        public bool CreatePlayer(PlayerCreate model)
        {
            //byte[] bytes = null;
            //if (model.File != null)
            //{
            //    Stream fileStream = model.File.InputStream;
            //    BinaryReader reader = new BinaryReader(fileStream);
            //    bytes = reader.ReadBytes((Int32)fileStream.Length);
            //}
            var player =
            new Player()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                JerseyNumber = model.JerseyNumber,
                Height = model.Height,
                Weight = model.Weight,
                YearsWithTeam = model.YearsWithTeam,
                College = model.College,
                TwitterHandle = model.TwitterHandle,
                TeamId = model.TeamId,
                //Contents =bytes
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
                            TeamName = e.Team.TeamName,
                            JerseyNumber = e.JerseyNumber,

                        }
                        );
                return allplayers.ToArray();
            }

        }

        public IEnumerable<Player> GetPlayersData()
        {
            using (var ctx = new ApplicationDbContext())
            {
                return ctx.Players.ToList();
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
                        PlayerId = player.PlayerId,
                        FirstName = player.FirstName,
                        LastName = player.LastName,
                        Age = player.Age,
                        DateOfBirth = player.DateOfBirth,
                        Height = player.Height,
                        Weight = player.Weight,
                        YearsWithTeam = player.YearsWithTeam,
                        JerseyNumber = player.JerseyNumber,
                        TeamName = GetTeamName(id),
                        College = player.College,
                        TwitterHandle = GetTwitterHandle(id),
                        //Contents = player.Contents
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
                return allplayers.ToArray().OrderBy(e => e.LastName);
            }
        }

        public bool UpdatePlayer(PlayerEdit model)
        {
            //Stream fileStream = model.File.InputStream;
            //BinaryReader reader = new BinaryReader(fileStream);
            //byte[] bytes = reader.ReadBytes((Int32)fileStream.Length);

            using (var ctx = new ApplicationDbContext())
            {
                var updates =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == model.PlayerId);

                updates.FirstName = model.FirstName;
                updates.LastName = model.LastName;
                updates.Weight = model.Weight;
                updates.Height = model.Height;
                updates.JerseyNumber = model.JerseyNumber;
                updates.YearsWithTeam = model.YearsWithTeam;
                updates.TeamId = model.TeamId;
                updates.TwitterHandle = model.TwitterHandle;

                return ctx.SaveChanges() == 1;


            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == id);
                ctx.Players.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

        public string GetTeamName(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var team =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == id)
                    .Team;

                if (team == null)
                {
                    return "None.";
                }

                else
                    using (var context = new ApplicationDbContext())
                    {
                        var entity =
                            context
                            .Players
                            .Single(e => e.PlayerId == id);

                        return entity.Team.TeamName;
                    };
            }
        }

        public string GetTwitterHandle(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var player =
                    ctx
                    .Players
                    .Single(e => e.PlayerId == id);



                if (player.TwitterHandle == null)
                {
                    return "_";
                }

                else
                    using (var context = new ApplicationDbContext())
                    {
                        var entity =
                            context
                            .Players
                            .Single(e => e.PlayerId == id);

                        return entity.TwitterHandle;
                    };
            }
        }
    }
}

