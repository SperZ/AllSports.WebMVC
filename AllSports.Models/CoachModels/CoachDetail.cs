using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.CoachModels
{
   public  class CoachDetail
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Years With Team")]
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        [Display(Name = "Coaching Position ")]
        public TypeOfCoach CoachPosition { get; set; }
        public int? TeamId { get; set; }
        [Display(Name = "Team")]
        public string TeamName { get; set; }
    }
}
