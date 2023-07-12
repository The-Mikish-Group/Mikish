using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mikish.Models;

namespace Mikish.Controllers
{
    public class PicturesController : Controller
    {
        private readonly ILogger<PicturesController> _logger;

        public PicturesController(ILogger<PicturesController> logger)
        {
            _logger = logger;
        }

        // Our Views
        public IActionResult Index()
        {
            ViewBag.Message = "Pictures";
            return View("Humor");
        }

        public IActionResult Humor()
        {
            ViewBag.Message = "Humor";
            return View();
        }

        public IActionResult Photos()
        {
            ViewBag.Message = "Photos";
            return View();
        }

        public IActionResult JeanMeeus()
        {
            ViewBag.Message = "JeanMeeus";
            return View();
        }

        public IActionResult Wildlife()
        {
            ViewBag.Message = "Wildlife";
            return View("_Images");
        }

        public IActionResult Fishing()
        {
            ViewBag.Message = "Fishing";
            return View("_Images");
        }

        public IActionResult Sunsets()
        {
            ViewBag.Message = "Sunsets";
            return View("_Images");
        }

        public IActionResult ScentMe()
        {
            ViewBag.Message = "ScentMe";
            return View("_Images");
        }

        public IActionResult Political()
        {
            ViewBag.Message = "Political";
            return View("_Images");
        }

        public IActionResult Memes()
        {
            ViewBag.Message = "Memes";
            return View("_Images");
        }
        public IActionResult Cartoons()
        {
            ViewBag.Message = "Cartoons";
            return View("_Images");
        }
        public IActionResult Jokes()
        {
            ViewBag.Message = "Jokes";
            return View("_Images");
        }
        public IActionResult NSFW()
        {
            ViewBag.Message = "NSFW";
            return View("_Images");
        }

        public IActionResult Totempole()
        {
            ViewBag.Message = "Totempole";
            return View();
        }

        public IActionResult Snow1()
        {
            ViewBag.Message = "Snow1";
            return View();
        }

        public IActionResult Snow2()
        {
            ViewBag.Message = "Snow2";
            return View();
        }

        public IActionResult Snow3()
        {
            ViewBag.Message = "Snow3";
            return View();
        }

        public IActionResult Snow4()
        {
            ViewBag.Message = "Snow4";
            return View();
        }

        public IActionResult Snow5()
        {
            ViewBag.Message = "Snow5";
            return View();
        }

        public IActionResult SvgFiles()
        {
            ViewBag.Message = "SvgFiles";
            return View();
        }

        public IActionResult Test()
        {
            ViewBag.Message = "Test";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}