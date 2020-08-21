using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
