using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mikish.Models;

namespace Mikish.Controllers
{
    public class InfoController : Controller
    {
        private readonly ILogger<InfoController> _logger;

        public InfoController(ILogger<InfoController> logger)
        {
            _logger = logger;
        }

        // Our Views
        public IActionResult Index()
        {
            ViewBag.Message = "About";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Message = "About";
            return View("Index");
        }
        
        public IActionResult Contact()
        {
            ViewBag.Message = "Contact";
            return View();
        }
        public IActionResult TOS()
        {
            ViewBag.Message = "TOS";
            return View();
        }
        public IActionResult Privacy()
        {
            ViewBag.Message = "Privacy";
            return View();
        }

        public IActionResult Elephant()
        {
            ViewBag.Message = "Elephant";
            return View();
        }

        public IActionResult Links()
        {
            ViewBag.Message = "Links";
            return View();
        }

        public IActionResult More()
        {
            ViewBag.Message = "More";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}