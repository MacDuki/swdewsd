using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomeClient()
        {
            return View();
        }
    }
}
