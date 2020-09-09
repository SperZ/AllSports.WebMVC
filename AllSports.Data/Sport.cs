using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class Sport
    {
        [Key]
        public int SportId { get; set; }
        [Required]
        public string SportName { get; set; }
        [Required]
        public int YearInvented { get; set; }
        public string Description { get; set; }
        public virtual ICollection<League> Leagues { get; set; }
    }
}
