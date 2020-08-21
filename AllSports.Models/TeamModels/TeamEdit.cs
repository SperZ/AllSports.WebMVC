using AllSports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.TeamModels
{
    public class TeamEdit
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public string CityName { get; set; }
        public StateAbbreviation State { get; set; }
        public string TeamOwner { get; set; }
    }
}
