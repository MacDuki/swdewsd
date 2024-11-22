using Microsoft.AspNetCore.Mvc;
using Dominio;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
namespace testing_Front.Controllers
{

    public class LoginController : Controller
    {
        Sistema system = Sistema.Instancia;

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ErrorLogin()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CheckClient(string inputGmail, string inputPass)
        {
            // Precarga de datos inicial y única.
            system.PrecargaDeDatos();
            Usuario? oneUser = system.ObtenerUsuario(inputGmail, inputPass);

            if (oneUser != null)
            {
                HttpContext.Session.SetString("Usuario", inputGmail); // Establecer variable de sesión "Usuario"

                if (oneUser is Cliente)
                {
                    HttpContext.Session.SetString("Rol", "Cliente");
                    HttpContext.Session.SetInt32("UserId", oneUser.Id);
                    return RedirectToAction("HomeClient", "Home", new { id = oneUser.Id });
                }
                else
                {
                    HttpContext.Session.SetString("Rol", "Administrador");
                    HttpContext.Session.SetInt32("UserId", oneUser.Id);
                    return RedirectToAction("HomeAdm", "Home", new { id = oneUser.Id });
                }
            }
            else
            {
                ViewBag.Mensaje = "Credenciales incorrectas. No existe un usuario con los datos ingresados.";
                return RedirectToAction("ErrorLogin", "Login");
            }
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();

            return RedirectToAction("index");
        }
    }
}
