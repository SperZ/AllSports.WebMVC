using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int YearsWithTeam { get; set; }
        public string College { get; set; }
        public TypeOfCoach CoachPosition { get; set; }
    }
}
