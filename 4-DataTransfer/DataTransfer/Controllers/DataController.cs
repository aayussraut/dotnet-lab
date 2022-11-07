using Microsoft.AspNetCore.Mvc;

namespace DataTransfer.Controllers
{
    public class DataController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
