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
        public string LeagueName { get; set; }
        [Required]
        public int NumberOfTeams { get; set; }
        public string Commisioner { get; set; }
        [Required]
        public int LeagueInception { get; set; }
        [Required]
        public string BaseCountry { get; set; }
        public int SportId { get; set; }
    }
}
