using Dominio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace testing_Front.Controllers
{
	public class LoginEjemploController : Controller
	{
		Sistema unSistema = Sistema.Instancia;

		public IActionResult LoginUsuario()
		{
			return View();
		}

		[HttpPost]

		public IActionResult LoginUsuario(string email, string contrasenia)
		{
			Usuario? unUsuario = unSistema.ObtenerUsuario(email, contrasenia);

			if (unUsuario != null)
			{
				HttpContext.Session.SetString("Usuario", unUsuario.Email);

				if (unUsuario is Cliente)
				{
					HttpContext.Session.SetString("Rol", "Cliente");
				}
				else
				{
					HttpContext.Session.SetString("Rol", "Administrador");
				}

				return RedirectToAction("Index", new { id = unUsuario.Id }); //ACÁ RETORNAMOS UN DICCIONARIO CON EL ID DEL USUARIO.
			}
			else 
			{
				ViewBag.Mensaje = "Credenciales incorrectas. No existe un usuario con los datos ingresados.";
				return View(); 
			}
		}

		public IActionResult Index(int id) //ACÁ SE RECIBE EL ID ASOCIADO EN EL DICCIONARIO QUE DECLARAMOS EN EL IACTIONRESULT DE ARRIBA. 
		{
			Usuario? unUsuario = unSistema.ObtenerUsuarioPorId(id);

			
			ViewBag.Rol = HttpContext.Session.GetString("Rol"); //ALMACENAMOS EL ROL DEL USUARIO EN LA VIEWBAG.
			return View(unUsuario);
		}

		public IActionResult Logout() 
		{
			HttpContext.Session.Clear();

			return RedirectToAction("LoginUsuario"); 
		}
	}
}
