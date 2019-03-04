using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SSGeek.Web.Models
{
    public class AlienTravelModel
    {
        const double earthYear = 365.26;
        const double earthHoursInAYear = 8765.82;


        [Display(Name = "Choose a mode of transport")]
        public string Mode { get; set; }

        [Display(Name = "Choose a planet")]
        public string Planet { get; set; }

        [Display(Name = "Enter your Earth age")]
        public double Age { get; set; }

        public static List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };

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

        public double TravelConversion()
        {
            //double age = Age * earthYear;
            Dictionary<string, double> modeDict = new Dictionary<string, double>()
            {
                {   "walking", 3 },
                {   "car", 100 },
                {   "bullet train", 200 },
                {   "boeing 747", 570 },
                {   "concorde", 1350 },
            };

            Dictionary<string, double> planetDict = new Dictionary<string, double>()
            {
            { "Mercury", 56974146 },
            { "Venus", 25724767 },
            { "Mars", 48678219 },
            { "Jupiter", 390647710 },
            { "Saturn", 792248270},
            { "Neptune", 2703959960 },
            { "Uranus", 1692662530 } };

            return planetDict[Planet] / modeDict[Mode] / earthHoursInAYear;
        }

        public double YearsTook()
        {
            return Age + TravelConversion();
        }
    }
}