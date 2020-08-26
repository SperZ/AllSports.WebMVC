using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.TeamModels
{
    public class TeamListItem
    {
        [Display(Name = "Id")]
        public int TeamId { get; set; }
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }
        [Display(Name = "Sport")]
        public string SportName { get; set; }
        [Display(Name = "League")]
        public string LeagueName { get; set; }
        
    }
}
