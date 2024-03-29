using HealthHub_MVC_CORE.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HealthHub_MVC_CORE.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        } public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        Ambulance ambobj = new Ambulance();
       
        [HttpPost]
        public IActionResult AddAmbulance(Ambulance ambulance)
        {

            bool res;
            ambobj = new Ambulance();
            res = ambobj.InsertAmbulance(ambulance);
            if (res)
            {
                TempData["msg"] = "Ambulance Added successfully";
            }
            else
            {
                TempData["msg"] = "Not Added. Something went wrong";
            }
            return View("Dashboard");
        }

    }
}
