using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.CoachModels
{
    public class CoachListItem
    {
        [Display(Name = "Id")]
        public int CoachId { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
    }
}
