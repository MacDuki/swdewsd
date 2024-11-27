using Dominio;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class RegisterController : Controller
    {
        Sistema system = Sistema.Instancia;


        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewClientRegister(Cliente oneClient)
        {
            try
            {
                system.AgregarCliente(oneClient);

                HttpContext.Session.SetString("Usuario", oneClient.Email);
                HttpContext.Session.SetString("Rol", "Cliente");
                HttpContext.Session.SetInt32("UserId", oneClient.Id);
                return RedirectToAction("HomeClient", "Home", new { id = oneClient.Id });
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message; 
                return View("FailureRegister");
            }

        }


        

     
    }
}
