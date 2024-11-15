using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema unSistema = Sistema.Instancia; 

        public IActionResult ListarPublicaciones()
        {
            if (HttpContext.Session.GetString("Usuario") == null) 
            {
                return Redirect("/LoginEjemplo/LoginUsuario");
            }

            //OBTENEMOS EL LISTADO DE TODAS LAS PUBLCIACIONES.
            return View(unSistema.ObtenerPublicaciones()); 
        }


    }
}
