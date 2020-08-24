using AllSports.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.CoachModels
{
    public class Team_CoachListItem
    {
        public int CoachId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public TypeOfCoach CoachPosition { get; set; }
        public int? YearsWithTeam { get; set; }
    }
}
