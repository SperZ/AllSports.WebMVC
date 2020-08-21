using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
