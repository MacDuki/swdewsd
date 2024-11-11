using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class RegisterController : Controller
    {

        public IActionResult NewClientRegister(string firstName, string lastName, string email, string password)
        {

            Sistema system = new Sistema();
            system.PrecargaDeDatos();
            
            bool succeed = system.NewClientRegister( firstName, lastName, email, password);

            if (succeed)
            {
                return View("SuccessRegister");
            } else
            {
                return View("FailureRegister");
            }


           
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
