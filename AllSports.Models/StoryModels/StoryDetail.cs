using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.StoryModels
{
    public class StoryDetail
    {
        public string HeadLine { get; set; }
        public string Content { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        public string LastName { get; set; }
        public string TeamName { get; set; }
        [Display(Name = "Creator")]
        public string UserName { get; set; }
        [Display(Name ="Published")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
