using BusinessLayer.Entities;
using OopsConceptAspDotNetMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OopsConceptAspDotNetMvc.Controllers
{
    public class StudentsController : Controller
    {
         static List<City> city = new List<City>
        {
            new City { Id = 1, Name = "Ahmedabad" },
            new City { Id = 2, Name = "Gandhinagaar" },
            new City { Id = 3, Name = "Mumbai" },
            new City { Id = 4, Name = "Pune" },
            new City { Id = 5, Name = "Banglore" }
        };
        public JsonResult AutoCompleteSearch(string term)
        {
            var result = city.Where(p => p.Name.ToLower().Contains(term.ToLower()))
                                 .Select(p => new { label = p.Name, value = p.Id })
                                 .ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

    }
}
