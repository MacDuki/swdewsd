using Dominio;
using Microsoft.AspNetCore.Mvc;
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
			// Precarga de datos inicial y �nica.
			system.PrecargaDeDatos();

			try
			{
				Usuario? oneUser = system.ObtenerUsuario(inputGmail, inputPass);

				if (oneUser != null)
				{
					HttpContext.Session.SetString("Usuario", inputGmail); // Establecer variable de sesi�n "Usuario" con valor de mail

					if (oneUser is Cliente)
					{
						HttpContext.Session.SetString("Rol", "Cliente");
						HttpContext.Session.SetInt32("UserId", oneUser.Id);
						return RedirectToAction("HomeClient", "Home");
					}
					else
					{
						HttpContext.Session.SetString("Rol", "Administrador");
						HttpContext.Session.SetInt32("UserId", oneUser.Id);
						return RedirectToAction("HomeAdm", "Home");
					}
				}
				else
				{
					ViewBag.ErrorMessageLogin = "Credenciales incorrectas. No existe un usuario con los datos ingresados.";
					return View("ErrorLogin");
				}
			}
			catch (Exception ex)
			{
				ViewBag.ErrorMessageLogin = ex.Message;
				return View("ErrorLogin");

			}
		}


		public IActionResult Logout()
		{
			HttpContext.Session.Clear();

			return RedirectToAction("Index");
		}
	}
}
