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
				return View(system.ObtenerPublicaciones());
			}
			else
			{
				return RedirectToAction("Index", "ErrorCredentials");
			}
		}

        public IActionResult RealizarCompra(int idPublicacion)
        {
            if (HttpContext.Session.GetString("Rol") != "Cliente")
            {
                return Redirect("/Login/Index");
            }

            string emailCliente = HttpContext.Session.GetString("Usuario");

            try
            {
                system.ProcesarCompra(emailCliente, idPublicacion);
                ViewBag.Mensaje = "Compra realizada con éxito.";
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
            }

            return View("OperationResult");
        }

        public IActionResult HomeAdm(int id)
		{
			Usuario? oneUser = system.ObtenerUsuarioPorId(id);
			string? rol = HttpContext.Session.GetString("Rol");
			int? userId = HttpContext.Session.GetInt32("UserId");
			if (oneUser != null && oneUser is Administrador && rol == "Administrador" && userId == id)
			{
				return View(system.ObtenerSubastas());
			}
			else
			{
				return RedirectToAction("Index", "ErrorCredentials");
			}
		}

	}
}
