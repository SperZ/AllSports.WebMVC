using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.PlayerModels
{
    public class PlayerListItem
    {
        public int PlayerId { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name ="Last Name")]
        public string LastName { get; set; }
        public int Age { get; set; }
        [Display(Name = "Jersey Number")]
        public int? JerseyNumber { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
    }
}
