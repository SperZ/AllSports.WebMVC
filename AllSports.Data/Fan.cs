using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class Fan :IPerson , ILocation
    {
        [Key]
        public int FanId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public StateAbbreviation State { get; set; }
        public string CityName { get; set; }
        public ICollection<Team> Team { get; set; }
    }
}
