using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllSports.Models.TeamModels
{
   public  class TeamCreate
    {
        [Required]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }
        [Required]
        [Display(Name = "State")]
        public StateAbbreviation State { get; set; }
        [Display(Name = "League")]
        public int LeagueId { get; set; }
        //public byte[] Contents { get; set; }
        //[Display(Name = "Photo")]
        //[NotMapped]
        //public HttpPostedFileBase File { get; set; }
    }
}
