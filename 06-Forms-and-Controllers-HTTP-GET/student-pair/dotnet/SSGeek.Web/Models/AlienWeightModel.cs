﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienWeightModel
    {
        [Display(Name = "Choose a planet")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth weight")]
        public int Weight { get; set; }



        public static List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury"},
            new SelectListItem() { Text = "Venus"},
            new SelectListItem() { Text = "Mars"},
            new SelectListItem() { Text = "Jupiter"},
            new SelectListItem() { Text = "Saturn"},
            new SelectListItem() { Text = "Neptune"},
            new SelectListItem() { Text = "Uranus"}
        };

        public double WeightConversion()
        {
            Dictionary<string, double> planetDict = new Dictionary<string, double>()
           {
            { "Mercury", .38 },
            { "Venus", .91 },
            { "Mars", .38 },
            { "Jupiter", 2.34 },
            { "Saturn", .93 },
            { "Neptune", 1.12 },
            { "Uranus", .92 } };
           
            return Weight * planetDict[Planet];
        }
    }
}