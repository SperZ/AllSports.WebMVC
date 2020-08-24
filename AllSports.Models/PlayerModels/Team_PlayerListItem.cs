using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.PlayerModels
{
    public class Team_PlayerListItem
    {
        public int TeamId { get; set; }
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int? JerseyNumber { get; set; }
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        
    }
}
