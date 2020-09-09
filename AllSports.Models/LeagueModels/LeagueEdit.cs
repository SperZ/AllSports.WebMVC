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
        [Display(Name = "League Name")]
        public string LeagueName { get; set; }
        [Display(Name = "Number of Teams")]
        public int NumberOfTeams { get; set; }
        [Display(Name ="Base Country")]
        public string BaseCountry { get; set; }
    }
}
