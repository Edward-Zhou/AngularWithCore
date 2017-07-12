using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace AngularWithCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Save(string value)
        {
            return value;
        }
        [HttpGet]
        public IActionResult SaveView()
        {
            return View();
        }
        [HttpGet]
        public string GetData()
        {
            return "Hello World";
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string SaveViewPost()
        {
            return "OK";
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Hello Word";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
