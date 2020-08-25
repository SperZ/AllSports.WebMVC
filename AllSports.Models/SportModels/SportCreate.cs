using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.SportModels
{
    public class SportCreate
    {
        [Required]
        [Display(Name = "Sport")]
        public string SportName { get; set; }
        [Required]
        [Display(Name = "Year Invented")]
        public int YearInvented { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
