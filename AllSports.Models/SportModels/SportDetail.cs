using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.SportModels
{
    public class SportDetail
    {
        public int SportId { get; set; }
        public string SportName { get; set; }
        public int YearInvented { get; set; }
        public string Description { get; set; }
    }
}
