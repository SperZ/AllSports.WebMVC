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
    public class PlayerCreate
    {
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Date Of Birth")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        [Display(Name = "Jersey Number")]
        public int? JerseyNumber { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        [Display(Name =  "Years with Team")]
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        [Display(Name = "Twitter Handle")]
        [DataType(DataType.Url)]
        public string TwitterHandle { get; set; }
        [Display(Name = "Team")]
        public int? TeamId { get; set; }

        public byte[] Contents { get; set; }
        [Display(Name = "Photo")]
        [NotMapped]
        public HttpPostedFileBase File { get; set; }
    }
}
