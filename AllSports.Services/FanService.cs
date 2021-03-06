﻿using AllSports.Data;
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

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Fans.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public bool ConnectFanToTeam(int Id, ConnectFan model)// not added to controller
        {
            using (var ctx = new ApplicationDbContext())
            {
                var fan =
                    ctx
                    .Fans
                    .Single(e => e.UserName == _userName && e.FanId == Id);
              

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
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Fans
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


        public IEnumerable<FanListItem> GetFansByTeamId(int teamId)// not added to controller
        {
            using (var ctx = new ApplicationDbContext())
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
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Fans
                    .Single(e => e.FanId == id);
                return
                   new FanDetail()
                   {
                       FanId = entity.FanId,
                       FirstName = entity.FirstName,
                       LastName = entity.LastName,
                       State = entity.State,
                       CityName = entity.CityName,
                       UserName = entity.UserName
                   };
            }
        }

        public bool UpdateFan(FanEdit model) // added to controller but not working throws error on razor page return to index view.
        {
            using (var ctx = new ApplicationDbContext())
            {
                var updates =
                    ctx
                    .Fans
                    .Single(e => e.UserName ==_userName && e.FanId == model.FanId);

                updates.FirstName = model.FirstName;
                updates.LastName = model.LastName;
                updates.CityName = model.CityName;
                updates.State = model.State;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool Delete(int id)
        {
            using (var ctx = new ApplicationDbContext())
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
