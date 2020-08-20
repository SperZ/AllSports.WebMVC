using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class Team : ILocation
    {
        [Key]
        public int TeamId { get; set; }
        public string TeamName { get; set; }
        public string LocationName { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal WinPercentage { get; set; }
        public string CityName { get; set; }
        public StateAbbreviation State { get; set; }
        public int LeagueId { get; set; }
        [ForeignKey(nameof(LeagueId))]
        public virtual League League { get; set; }
        public virtual ICollection<Fan> Fan { get; set; }
    }
}
