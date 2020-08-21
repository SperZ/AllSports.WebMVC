using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class League_TeamListItem
    {
        public int LeagueId { get; set; }
        public string TeamName { get; set; }
        public string CityName { get; set; }
        public StateAbbreviation State { get; set; }
        [DefaultValue(0)]
        public int Wins { get; set; }
        [DefaultValue(0)]
        public int Losses { get; set; }
        public decimal? WinPercentage { get; set; }
    }
}
