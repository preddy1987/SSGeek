using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SSGeek.Web.Models;

namespace SSGeek.Web.Controllers
{
    public class CalculatorsController : Controller
    {
        // INSTRUCTIONS
        // As a part of each exercise you will need to 
        // - develop a view for AlienAge, AlienWeight, and AlienTravel that displays a form to submit data
        // - create a new action to process the form submission (e.g. AlienAgeResult, AlienWeightResult, etc.)
        // - create a view that displays the submitted form result

        
        // GET: Calculators/AlienWeight
        public ActionResult AlienWeight()
        {
            return View();
        }

        // GET: calcualtors/alienweightresult?planet=xyz&weight=123
        public ActionResult AlienWeightResult(AlienWeightModel model)
        {
            return View(model);
        }

        // GET: Calculators/AlienAge
        public ActionResult AlienAge()
        {
            return View();
        }

        // GET: calcualtors/alienageresult?planet=xyz&age=123
        public ActionResult AlienAgeResult(AlienTravelModel model)
        {
            return View(model);
        }

        // GET: Calculators/AlienTravel
        public ActionResult AlienTravel()
        {
            return View();
        }

        // GET: calcualtors/alientravelresult?planet=xyz&mode&age=123
        public ActionResult AlienTravelResult(AlienTravelModel model)
        {
            return View(model);
        }



        private List<SelectListItem> planets = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Mercury", Value= "0.38" },
            new SelectListItem() { Text = "Venus", Value= "0.91" },
            new SelectListItem() { Text = "Mars", Value= "0.38"  },
            new SelectListItem() { Text = "Jupiter", Value= "2.34"  },
            new SelectListItem() { Text = "Saturn", Value= "0.93"  },
            new SelectListItem() { Text = "Neptune", Value= "1.12"  },
            new SelectListItem() { Text = "Uranus", Value= "0.92"  }
        };

        private List<SelectListItem> transportationModes = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Walking", Value="walking" },
            new SelectListItem() { Text = "Car", Value = "car" },
            new SelectListItem() { Text = "Bullet Train", Value = "bullet train" },
            new SelectListItem() { Text = "Boeing 747", Value = "boeing 747" },
            new SelectListItem() { Text = "Concorde", Value = "concorde" }
        };
    }
}