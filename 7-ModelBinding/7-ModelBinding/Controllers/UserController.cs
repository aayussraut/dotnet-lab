using _7_ModelBinding.Models;
using Microsoft.AspNetCore.Mvc;

namespace _7_ModelBinding.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Family()
        {
            return View(new FamilyModel { id = 1, full_name = "Aayush Raut", age = 22, gender = "Male", relation = Relation.None });

        }
        [HttpPost]
        public IActionResult Family(FamilyModel u)
        {
            
                return Content($"User {u.ToString()} updated!");
        }
    }
}
