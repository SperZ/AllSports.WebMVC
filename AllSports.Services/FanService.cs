using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
