using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class LeagueEdit
    {
        public int LeagueId { get; set; }
        public string LeagueName { get; set; }
        public int NumberOfTeams { get; set; }
        public string Commisioner { get; set; }
        public string BaseCountry { get; set; }
    }
}
