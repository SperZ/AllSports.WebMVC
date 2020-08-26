using AllSports.Data;
using AllSports.Models.SportModels;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Services
{
    public class SportService
    {
        private readonly string _userName;
        public SportService(string userName)
        {
            _userName = userName;
        }

        public bool CreateSport(SportCreate model)
        {
            var entity =
                new Sport() 
                { 
                    SportName = model.SportName,
                    YearInvented = model.YearInvented,
                    Description = model.Description
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sports.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SportListItem> GetSports()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var allsports =
                    ctx
                    .Sports
                    .Select(
                        e =>
                        new SportListItem{ 
                            SportId = e.SportId,
                            SportName = e.SportName,
                            YearInvented = e.YearInvented
                        }

                        );
                return allsports.ToArray();
            }
        }

        public SportDetail GetSportbyId(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sports
                    .Single(e => e.SportId == id);
                return
                    new SportDetail { 
                        SportName=entity.SportName,
                        YearInvented =entity.YearInvented,
                        Description= entity.Description
                    };
            }
        }

        public bool Delete(int id)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Sports
                    .Single(e => e.SportId == id);

                ctx.Sports.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
