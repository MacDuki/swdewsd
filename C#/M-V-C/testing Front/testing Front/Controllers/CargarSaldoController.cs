using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class CargarSaldoController : Controller
    {
        Sistema unSistema = Sistema.Instancia; 
        public IActionResult CargarSaldo()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CargarSaldo(decimal saldo) 
        {
            if (HttpContext.Session.GetString("Usuario") == null) 
            {
                return RedirectToAction("/LoginEjemplo/LoginUsuario");
            }

            string emailUsuarioLogueado= HttpContext.Session.GetString("Usuario");
            try
            {
                Cliente clienteACargar = unSistema.ObtenerClienteMail(emailUsuarioLogueado);
                clienteACargar.CargarSaldo(saldo);
                ViewBag.Mensaje = "Saldo agregado con éxito."; 
            }
            catch (Exception ex) 
            {
                ViewBag.Error = ex.Message; 
            }
    


            return View(); 
        }
    }
}
