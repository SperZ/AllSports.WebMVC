using AllSports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.FanModels
{
    public class FanEdit
    {
        public int FanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StateAbbreviation State { get; set; }
        public string CityName { get; set; }
    }
}
