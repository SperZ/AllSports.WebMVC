using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class Player : IPerson , IInfo
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        public int Age { get; set; }
        public int? JerseyNumber { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        public string TwitterHandle { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }

    }    
}

