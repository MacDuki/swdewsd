using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
    public class CargarSaldoController : Controller
    {
        Sistema unSistema = Sistema.Instancia;
        public IActionResult Index()
        {
            string emailUsuarioLogueado = HttpContext.Session.GetString("Usuario");
            if (emailUsuarioLogueado == null)
            {
                // Si no hay usuario logueado, redirige al login
                return RedirectToAction("Index", "ErrorCredentials");
            } else
            {
                HttpContext.Session.SetString("LoadMoneyOperation", "");
                return View();
            }

        }

        [HttpPost]
        public IActionResult IncreaseMoney(decimal saldo)
        {
            string emailUsuarioLogueado = HttpContext.Session.GetString("Usuario");
            try
            {
                Cliente clienteACargar = unSistema.ObtenerClienteMail(emailUsuarioLogueado);
                if (saldo > 0)
                {
                    clienteACargar.CargarSaldo(saldo);
                    HttpContext.Session.SetString("LoadMoneyOperation", saldo.ToString());
                    return RedirectToAction("Index", "OperationsResults");

                } else { 
                    ViewBag.Error = "Saldo no cargado, verifique que el monto sea mayor a 0.";
                    return View("Index");
                }
              
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("Index");
        }


    }






}



