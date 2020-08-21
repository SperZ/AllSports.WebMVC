using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.PlayerModels
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int? JerseyNumber { get; set; }
        public string Height { get; set; }
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        public string TwitterHandle { get; set; }
        public int? TeamId { get; set; }
    }
}
