using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class SubastaController : Controller
    {
        Sistema unSistema = Sistema.Instancia; 

        public IActionResult ListarSubastas()
        {
            if (HttpContext.Session.GetString("Usuario") == null || HttpContext.Session.GetString("Rol") != "Administrador") 
            {
                return Redirect("/LoginEjemplo/LoginUsuario"); 
            }

            return View(unSistema.ObtenerSubastas());
        }

    }
}
