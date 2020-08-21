using AllSports.Models.TeamModels;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool Create(TeamCreate model)
        {
            var entity =
               
        }
    }
}
