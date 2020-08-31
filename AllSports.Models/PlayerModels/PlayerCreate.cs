using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.PlayerModels
{
    public class PlayerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Jersey Number")]
        public int? JerseyNumber { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Display(Name =  "Years with Team")]
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        [Display(Name = "Twitter Handle")]
        public string TwitterHandle { get; set; }
        [Display(Name = "Team")]
        public int? TeamId { get; set; }
    }
}
