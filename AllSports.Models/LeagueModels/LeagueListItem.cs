using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class LeagueListItem
    {
        [Display(Name = "Id")]
        public int LeagueId { get; set; }
        [Display(Name = "League")]
        public string LeagueName { get; set; }
    }
}
