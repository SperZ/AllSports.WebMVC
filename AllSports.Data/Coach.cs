using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public enum TypeOfCoach { HeadCoach, AssistantCoach }
    public class Coach : IPerson , IInfo
    {
        [Key]
        public int CoachId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

        public string FullName { get 
            {
                var fullName = $"{FirstName} {LastName}";
                return fullName;
            } 
        }
        public int? YearsWithTeam { get; set;}
        public string College { get; set; }
        public TypeOfCoach CoachPosition { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
    }
}
