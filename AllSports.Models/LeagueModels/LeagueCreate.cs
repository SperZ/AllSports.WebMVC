using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class LeagueCreate
    {
        [Required]
        [Display(Name = "Name of League")]
        public string LeagueName { get; set; }
        [Required]
        [Display(Name = "Number Of Teams")]
        public int NumberOfTeams { get; set; }
        [Required]
        [Display(Name = "Year of Inception")]
        public int LeagueInception { get; set; }
        [Required]
        [Display(Name = "Base Country")]
        public string BaseCountry { get; set; }
        public int SportId { get; set; }
    }
}
