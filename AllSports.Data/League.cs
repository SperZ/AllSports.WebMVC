using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class League
    {
        [Key]
        public int LeagueId { get; set; }
        [Required]
        public string LeagueName { get; set; }
        [Required]
        public int NumberOfTeams { get; set; }
        [Required]
        public int LeagueInception { get; set; }
        [Required]
        public string BaseCountry { get; set; }
        public int SportId { get; set; }
        [ForeignKey(nameof(SportId))]
        public virtual Sport Sport { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
