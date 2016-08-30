using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using MvcVehicle.Models;
using System.Net.Http;

namespace MvcVehicle.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {          

            return View();
        }

   /*     public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
                        
            return View();
        }
*/
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidateReCaptchaAttribute))]
        public IActionResult About()
        {
            if (ModelState.IsValid)
            {
                @ViewData["Message"] = "Model valid";
            }
            else
            {
                @ViewData["Message"] = "Invalid!!!";
            }
            return View();
        }


    }
}
