using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AngularWithCore.Data;
using Microsoft.AspNetCore.Identity;
using AngularWithCore.Models;
using SampleSvc;
using AngularWithCore.Helper;

namespace AngularWithCore.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ApplicationDbContext context,UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            //var current_User = _userManager.GetUserAsync(HttpContext.User).Result;
            //string current_User_Id = "" + current_User.Id;
            var header = Request.Headers["New Header"];
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Save(string value)
        {
            SampleClient client = new SampleClient();
            client.ClientCredentials.ServiceCertificate.SslCertificateAuthentication = new System.ServiceModel.Security.X509ServiceCertificateAuthentication
            {
                CertificateValidationMode=System.ServiceModel.Security.X509CertificateValidationMode.Custom,
                CustomCertificateValidator = new MyX509CertificateValidator("CN=Contoso.com")
            };
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
