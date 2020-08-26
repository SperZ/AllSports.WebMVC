using AllSports.Data;
using AllSports.Models.FanModels;
using AllSports.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class FanService
    {
        private readonly string _userName;
        public FanService(string userName)
        {
            _userName = userName;
        }
        public bool CreateFan(FanCreate model)
        {
            var entity =
                new Fan()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    State = model.State,
                    CityName = model.CityName,
                    UserName = _userName
                };

            using(var ctx = new ApplicationDbContext())
            {
                ctx.Fans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool ConnectFanToTeam(int fanId, OnlyTeamId model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var fan =
                    ctx
                    .Fans
                    .Single(e => e.FanId == fanId && e.UserName == _userName);

                var team =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == model.TeamId);

                fan.Teams.Add(team);

                return ctx.SaveChanges() == 1;

            }
        }
        public IEnumerable<FanListItem> GetFans()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Fans
                    .Where(e => e.UserName == _userName)
                    .Select(e =>
                  new FanListItem 
                  {
                      FanId = e.FanId,
                      FirstName = e.FirstName,
                      CityName = e.CityName,
                  }
                  );
                return query.ToArray();
            }
        }


            public IEnumerable<FanListItem> GetFansByTeamId(int teamId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allfans =
                    ctx
                    .Teams
                    .Single(e => e.TeamId == teamId)
                    .Fans
                    .Select(
                        e =>
                        new FanListItem()
                        {
                            FanId = e.FanId,
                            FirstName = e.FirstName,
                            CityName = e.CityName
                        }
                        );
                return allfans.ToArray();
            }
        }

        public FanDetail GetFanbyId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Fans
                    .Single(e => e.FanId == id && e.UserName == _userName);
                return
                   new FanDetail()
                   {
                       FirstName = entity.FirstName,
                       LastName = entity.LastName,
                       State = entity.State,
                       CityName = entity.CityName,
                       UserName = entity.UserName
                   };
            }
        }

        public bool UpdatFan(FanEdit model) 
        {
            using(var ctx = new ApplicationDbContext())
            {
                var updates =
                    ctx
                    .Fans
                    .Single(e => e.FanId == model.FanId);
                updates.FirstName = model.FirstName;
                updates.LastName = model.LastName;
                updates.CityName = model.CityName;
                updates.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Fans
                    .Single(e => e.FanId == id && e.UserName == _userName);

                ctx.Fans.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
