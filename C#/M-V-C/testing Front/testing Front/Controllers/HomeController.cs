using Microsoft.AspNetCore.Mvc;
using Dominio;
namespace testing_Front.Controllers
{
    public class HomeController : Controller
    {
        Sistema system = Sistema.Instancia;
        public IActionResult HomeClient(int id)
        {
            Usuario? oneUser = system.ObtenerUsuarioPorId(id);
            string? rol = HttpContext.Session.GetString("Rol");
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (oneUser != null && oneUser is Cliente && rol == "Cliente" && userId == id)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "ErrorCredentials");
            }
        }

        public IActionResult HomeAdm(int id)
        {
            Usuario? oneUser = system.ObtenerUsuarioPorId(id);
            string? rol = HttpContext.Session.GetString("Rol");
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (oneUser != null && oneUser is Administrador && rol == "Administrador" && userId == id)
            {
                return View();
            } else
            {
                return RedirectToAction("Index", "ErrorCredentials");
            }
        }
    }
}
