using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.FanModels
{
    public class FanCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public StateAbbreviation State { get; set; }
        [Required]
        [Display(Name = "City")]
        public string CityName { get; set; }
        public string UserName { get; set; }
    }
}
