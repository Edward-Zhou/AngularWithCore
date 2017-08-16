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
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

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
            var isAuthenticated = User.Identity.IsAuthenticated;
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

        public IActionResult Login()
        {
            HttpClient client = new HttpClient();

            StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new Login { Username = "Test", Password = "1235" }), Encoding.UTF8, "application/json");
            var response = client.PostAsync("http://localhost:9336/api/values/WithOutBody", content).Result;
            var result = response.Content.ReadAsStringAsync();
            return Ok(result);
            //Login login = new Login() { Username = "username", Password = "password" };
            //HttpClient client = new HttpClient()
            //{
            //    BaseAddress = new Uri("http://localhost:44612/")
            //};
            //MediaTypeWithQualityHeaderValue contentType = new MediaTypeWithQualityHeaderValue("application/json");
            //client.DefaultRequestHeaders.Accept.Add(contentType);
            //HttpResponseMessage response = client.PostAsJsonAsync("/api/User/Login", login).Result;

            //if (response.IsSuccessStatusCode)
            //{
            //    return View();
            //}
            //else
            //{
            //    return View();
            //}
        }

        public IActionResult Error()
        {
            return View();
        }
    }
    public class Login
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
