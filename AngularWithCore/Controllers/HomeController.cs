using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularWithCore.Data;

namespace AngularWithCore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }
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
            ViewData["UserCount"] = _context.Users.Count();
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
