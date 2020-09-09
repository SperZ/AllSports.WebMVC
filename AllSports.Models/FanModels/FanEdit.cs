﻿using AllSports.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllSports.Models.FanModels
{
    public class FanEdit
    {
        [Display(Name = "Id")]
        public int FanId { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public StateAbbreviation State { get; set; }
        [Display(Name = "City")]
        public string CityName { get; set; }
    }
}
