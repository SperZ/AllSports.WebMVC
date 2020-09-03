using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.StoryModels
{
    public class StoryListItem
    {
        [Display(Name ="Id")]    
        public int StoryId { get; set; }
        public string HeadLine { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Published")]
        public DateTimeOffset CreatedUtc { get; set; }
    }
}
