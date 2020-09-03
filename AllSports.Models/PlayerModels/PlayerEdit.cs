using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllSports.Models.PlayerModels
{
    public class PlayerEdit
    {
        public int PlayerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? JerseyNumber { get; set; }
        public string Height { get; set; }
        public int Weight { get; set; }
        public int? YearsWithTeam { get; set; }
        public string TwitterHandle { get; set; }
        public int? TeamId { get; set; }
        //[Display(Name = "Photo")]
        //public byte[] Contents { get; set; }
        //[NotMapped]
        //public HttpPostedFileBase File { get; set; }
    }
}
