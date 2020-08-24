using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Required]
        public string TeamName { get; set; }
        [DefaultValue(0)]
        public int Wins { get; set; }
        [DefaultValue(0)]
        public int Losses { get; set; }
        public decimal WinPercentage {
            get
            {
                decimal percentage = Convert.ToDecimal(Wins / (Wins + Losses));
                return percentage;
            } 
        }
        [Required]
        public string CityName { get; set; }
        [Required]
        public StateAbbreviation State { get; set; }
        public int LeagueId { get; set; }
        [ForeignKey(nameof(LeagueId))]
        public virtual League League { get; set; }
        public virtual ICollection<Fan> Fans { get; set; }
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Coach> Coaches { get; set; }

        public Team()
        {
            this.Fans = new HashSet<Fan>();
        }
    }
}
