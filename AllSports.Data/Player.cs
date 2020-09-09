using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AllSports.Data
{
    public class Player : IPerson,  IInfo,  IPhoto
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string FullName
        {
            get 
            {
                string fullName = $"{FirstName} {LastName}";
                return fullName;
            }
        }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:d}")]
        [DataType(DataType.DateTime)]
        public DateTime DateOfBirth { get; set; }
        public int Age
        {
            get
            {
                TimeSpan ageSpan = DateTime.Now - DateOfBirth;
                double totalAgeInYear = ageSpan.TotalDays / 365.25;
                var age = Convert.ToInt32(Math.Floor(totalAgeInYear));
                return age;
            }
        }
        public int? JerseyNumber { get; set; }
        [Required]
        public string Height { get; set; }
        [Required]
        public int Weight { get; set; }
        public int? YearsWithTeam { get; set; }
        public string College { get; set; }
        //public int Salary { get; set; }
        public string TwitterHandle { get; set; }
        public int? TeamId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
        public ICollection<Story> Story { get; set; }
        public byte[] Contents { get; set; }
        [NotMapped]
        public HttpPostedFileBase File { get; set; }

    }    
}

