using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Mikish.Models;

namespace Mikish.Controllers
{
    public class CountdownsController : Controller
    {
        private readonly ILogger<CountdownsController> _logger;

        public CountdownsController(ILogger<CountdownsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("EventsMenu");
        }

        public IActionResult EventsMenu()
        {
            ViewBag.Message = "EventsMenu";
            return View();
        }

        public IActionResult Spring()
        {
            ViewBag.Message = "Spring";
            return View("_Countdown");
            
        }

        public IActionResult Summer()
        {
            ViewBag.Message = "Summer";
            return View("_Countdown");
        }

        public IActionResult Autumn()
        {
            ViewBag.Message = "Autumn";
            return View("_Countdown");
        }

        public IActionResult Winter()
        {
            ViewBag.Message = "Winter";
            return View("_Countdown");
        }

        public IActionResult NewYears()
        {
            ViewBag.Message = "NewYears";
            return View("_Countdown");
        }

        public IActionResult Valentines()
        {
            ViewBag.Message = "Valentines";
            return View("_Countdown");
        }

        public IActionResult Easter()
        {
            ViewBag.Message = "Easter";
            return View("_Countdown");
        }

        public IActionResult Mothers()
        {
            ViewBag.Message = "Mothers";
            return View("_Countdown");
        }

        public IActionResult Memorial()
        {
            ViewBag.Message = "Memorial";
            return View("_Countdown");
        }

        public IActionResult Independence()
        {
            ViewBag.Message = "Independence";
            return View("_Countdown");
        }

        public IActionResult Labor()
        {
            ViewBag.Message = "Labor";
            return View("_Countdown");
        }        

        public IActionResult Veterans()
        {
            ViewBag.Message = "Veterans";
            return View("_Countdown");
        }
        
        public IActionResult Halloween()
        {
            ViewBag.Message = "Halloween";
            return View("_Countdown");
        }

        public IActionResult Elections()
        {
            ViewBag.Message = "Elections";
            return View("_Countdown");
        }

        public IActionResult Christmas()
        {
            ViewBag.Message = "Christmas";
            return View("_Countdown");
        }

        public IActionResult Thanksgiving()
        {
            ViewBag.Message = "Thanksgiving";
            return View("_Countdown");
        }

        public IActionResult MartinLutherKing()
        {
            ViewBag.Message = "MartinLutherKing";
            return View("_Countdown");
        }

        public IActionResult Fathers()
        {
            ViewBag.Message = "Fathers";
            return View("_Countdown");
        }

        public IActionResult Presidents()
        {
            ViewBag.Message = "Presidents";
            return View("_Countdown");
        }

        public IActionResult Lincoln()
        {
            ViewBag.Message = "Lincoln";
            return View("_Countdown");
        }

        public IActionResult Washington()
        {
            ViewBag.Message = "Washington";
            return View("_Countdown");
        }

        public IActionResult Jefferson()
        {
            ViewBag.Message = "Jefferson";
            return View("_Countdown");
        }

        public IActionResult Army()
        {
            ViewBag.Message = "Army";
            return View("_Countdown");
        }

        public IActionResult AirForce()
        {
            ViewBag.Message = "AirForce";
            return View("_Countdown");
        }

        public IActionResult Navy()
        {
            ViewBag.Message = "Navy";
            return View("_Countdown");
        }

        public IActionResult MarineCorp()
        {
            ViewBag.Message = "MarineCorp";
            return View("_Countdown");
        }

        public IActionResult NationalGuard()
        {
            ViewBag.Message = "NationalGuard";
            return View("_Countdown");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

