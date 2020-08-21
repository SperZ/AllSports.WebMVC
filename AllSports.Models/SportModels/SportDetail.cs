using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.SportModels
{
    public class SportDetail
    {
        public int SportId { get; set; }
        [Display(Name = "Sport")]
        public string SportName { get; set; }
        [Display(Name = "Year Invented")]
        public int YearInvented { get; set; }
        public string Description { get; set; }
    }
}
