using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.StoryModels
{
    public class StoryCreate
    {
        [Display(Name = "HeadLine")]
        public string HeadLine { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
        public int? PlayerId { get; set; }
    }
}
