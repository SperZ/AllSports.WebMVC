﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.LeagueModels
{
    public class LeagueDetail
    {
        public int LeagueId { get; set; }
        [Display(Name = "League")]
        public string LeagueName { get; set; }
        public string Commisioner { get; set; }
        public int LeagueInception { get; set; }
        public int SportId { get; set; }
    }
}
