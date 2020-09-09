using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.CoachModels
{
    public class CoachEdit
    {
        public int CoachId { get; set; }
        [Display(Name ="First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name ="Years with Team")]
        public int? YearsWithTeam { get; set; }
        [Display(Name= "Coaching Position")]
        public TypeOfCoach CoachPosition { get; set; }
        public int? TeamId { get; set; }
    }
}
