using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienAgeModel
    {
        const double earthYear = 365.26;


        [Display(Name = "Choose a planet")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth age")]
        public double Age { get; set; }



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

        public double AgeConversion()
        {
            double age = Age * earthYear;

            Dictionary<string, double> planetDict = new Dictionary<string, double>()
            {
            { "Mercury", 87.96 },
            { "Venus", 224.68 },
            { "Mars", 686.98 },
            { "Jupiter", 11.862 },
            { "Saturn", 29.456 },
            { "Neptune", 164.81 },
            { "Uranus", 84.07 } };

            return age / planetDict[Planet];
        }
    }
}