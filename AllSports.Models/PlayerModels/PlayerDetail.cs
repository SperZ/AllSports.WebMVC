using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.PlayerModels
{
   public class PlayerDetail
    {
        public int PlayerId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Date of Birth")]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        [Display(Name = "Number")]
        public int? JerseyNumber { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        [Display(Name = "Years With Team")]
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        [Display(Name = "Twitter")]
        public string TwitterHandle { get; set; }
        public int? TeamId { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
    }
}
