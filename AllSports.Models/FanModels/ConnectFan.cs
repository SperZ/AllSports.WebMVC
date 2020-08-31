using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.FanModels
{
    public class ConnectFan
    {
        [Display(Name = "Team")]
        public int TeamId { get; set; }
    }
}
