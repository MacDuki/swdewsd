using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class PublicacionController : Controller
    {
        Sistema unSistema = Sistema.Instancia;

        public IActionResult Index() 
        {

            return View(); 
        }

        public IActionResult ListarPublicaciones()
        {
            if (HttpContext.Session.GetString("Usuario") == null) 
            {
                return Redirect("/Login/Index");
            }

            //OBTENEMOS EL LISTADO DE TODAS LAS PUBLCIACIONES.
            return View(unSistema.ObtenerPublicaciones()); 
        }

        //MÉTODO CORRESPONDIENTE A LA COMPRA DE UNA PUBLICACIÓN.
        [HttpPost]
        public IActionResult RealizarCompra(int idPublicacion)
        {
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                return Redirect("/Login/Index");
            }

            string emailCliente = HttpContext.Session.GetString("Usuario");

            try
            {
                unSistema.ProcesarCompra(emailCliente, idPublicacion);
                ViewBag.Mensaje = "Compra realizada con éxito.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Index");
        }

    }
}
