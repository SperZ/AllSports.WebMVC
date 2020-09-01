using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.StoryFolder
{
    public class StoryCreate
    {
        [Display(Name = "HeadLine")]
        public string HeadLine { get; set; }
        public string Content { get; set; }
        public int? PlayerId { get; set; }
    }
}
