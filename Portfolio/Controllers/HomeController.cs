using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Portfolio.Models;
using System.Diagnostics;

namespace Portfolio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataContext _ctx;

        public HomeController(ILogger<HomeController> logger, DataContext ctx)
        {
            _logger = logger;
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

      

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (!ModelState.IsValid)
            {
                return View(contact);
            }
            var AddContact = new Contact() { 
                Email = contact.Email, 
                Name = contact.Name, 
                Subject = contact.Subject, 
                Message = contact.Message 
            };
           //_ctx.Add(AddContact);
           //var res = _ctx.SaveChanges();
            if (contact == null)
            {
                TempData["Message"] = "MESSAGE NOT SENT, PLEASE TRY AGAIN";
                return View();
            }
            else
                //ViewBag.Message = "Saved";
                TempData["Message"] = "THANK YOU FOR CONTACTING ME. I WILL GET IN TOUCH WITH YOU SOON";

                return RedirectToAction("Index", "Home", "formarea");
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
