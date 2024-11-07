using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using testing_Front.Models;
using Dominio;
namespace testing_Front.Controllers
{
    public class LoginController : Controller
    {
       
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

      
        public IActionResult Index()
        {
            Sistema system = new Sistema();
            system.PrecargaDeDatos();
            List<Cliente> clientList = system.ListarClientes();
            ViewBag.ClientList = clientList;
            return View();
        }
        public IActionResult ErrorLogin()
        {

            return View();
        }
        public IActionResult CheckClient(string inputGmail, string inputPass)
        {
            Sistema system = new Sistema();
            system.PrecargaDeDatos();
            bool isClient = system.IsClient(inputGmail, inputPass);

            if (isClient)
            {

                return RedirectToAction("HomeClient", "Home");
            }
            else
            {
                // Cliente no encontrado, mostrar mensaje de error
                ViewBag.ErrorMessage = "Cliente no encontrado. Verifique sus datos.";
                return View("ErrorLogin"); 
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
