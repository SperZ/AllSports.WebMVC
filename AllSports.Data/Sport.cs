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
        public string SportName { get; set; }
    }
}
