using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.TeamModels
{
    public class TeamDetail
    {
        public int TeamId { get; set; }
        [Display(Name = "Team Name")]   
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        [Display(Name = "Win Percentage")]
        public decimal WinPercentage { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Display(Name = "State")]
        public StateAbbreviation State { get; set; }
        [Display(Name ="League")]
        public string LeagueName { get; set; }
    }
}
