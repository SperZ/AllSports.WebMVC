using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Data
{
    public class Story
    {
        public int StoryId { get; set; }

        public string HeadLine { get; set; }

        public string Description { get; set; }
        public int? TeamId { get; set; }
        public int? PlayerId { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual Team Team { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; }
    }
}
