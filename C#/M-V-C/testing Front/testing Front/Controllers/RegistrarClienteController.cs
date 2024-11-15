using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace testing_Front.Controllers
{
	public class RegistrarClienteController : Controller
	{
		Sistema unSistema = Sistema.Instancia; 

		public IActionResult AgregarCliente()
		{
			return View();
		}

		[HttpPost]

		public IActionResult AgregarCliente(Cliente unCliente) 
		{
			try
			{
				unSistema.AgregarCliente(unCliente);

				ViewBag.Mensaje = "¡Cliente registrado con éxito!"; 
			}
			catch (Exception ex) 
			{
				ViewBag.Error = ex; 
			}


			return View(unCliente); 
		}

	}
}
