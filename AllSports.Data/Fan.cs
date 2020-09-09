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
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public StateAbbreviation State { get; set; }
        [Required]
        public string CityName { get; set; }
        public string UserName { get; set; }
        public ICollection<Team> Teams { get; set; }

        public Fan()
        {
            this.Teams = new HashSet<Team>();
        }
    }
}
