using DataTransfer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataTransfer.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public IActionResult Index()
        {
            ViewBag.Message="This is a message from ViewBag";
            ViewData["Message2"]="This is a message from ViewData";
            TempData["msg"]="This is a message from TempData";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}