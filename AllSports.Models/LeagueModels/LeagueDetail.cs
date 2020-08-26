using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class LeagueDetail
    {
        [Display(Name = "League")]
        public string LeagueName { get; set; }
        [Display(Name = "Number Of Teams")]
        public int NumberOfTeams { get; set; }
        [Display(Name = "Year of Inception")]
        public int LeagueInception { get; set; }
        [Display(Name = "Country")]
        public string BaseCountry { get; set; }
        [Display(Name = "Sport")]
        public string SportName { get; set; }
    }
}
