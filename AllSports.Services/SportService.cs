using System;
using System.Collections.Generic;
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
    }
}
