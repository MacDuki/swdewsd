using Dominio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace testing_Front.Controllers
{
	public class HomeController : Controller
	{
		Sistema system = Sistema.Instancia;

		public IActionResult HomeClient()
		{
            Usuario? oneUser = null;
            int? userIdFromSession = HttpContext.Session.GetInt32("UserId"); 

           if (userIdFromSession.HasValue)  //  intentamos obtenerlo de la sesión
            {
                oneUser = system.ObtenerUsuarioPorId(userIdFromSession.Value);
            } else
			{
                return RedirectToAction("Index", "ErrorCredentials");
            }


            string? rol = HttpContext.Session.GetString("Rol");
			int? userId = HttpContext.Session.GetInt32("UserId");
			if (oneUser != null && oneUser is Cliente cliente && rol == "Cliente")
			{
				HttpContext.Session.SetString("UserName", cliente.Nombre);
				HttpContext.Session.SetString("Money", cliente.SaldoDisponible.ToString());
          
                return View(system.ObtenerPublicaciones());
			}
			else
			{
				return RedirectToAction("Index", "ErrorCredentials");
			}

            
        }

        public IActionResult RealizarCompra(int idPublicacion)
        {
           
            string emailCliente = HttpContext.Session.GetString("Usuario");
			Cliente cliente = system.ObtenerClienteMail(emailCliente);
			Venta thisSold = system.ObtenerVentaPorId (idPublicacion);
            try
            {
                system.ProcesarCompra(emailCliente, idPublicacion);
				
                HttpContext.Session.SetString("Money", cliente.SaldoDisponible.ToString());
                HttpContext.Session.SetString("BuyOperation", thisSold.ObtenerPrecio().ToString());
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("BuyOperation", "No se pudo procesar la operación por falta de saldo");
            }
            return RedirectToAction("Index", "OperationsResults");
      
        }

        [HttpPost]
        public IActionResult RealizeOffer(int idPublicacion, float monto)
        {
            int? idCliente = HttpContext.Session.GetInt32("UserId");


            try
            {
                Subasta? unaSubasta = system.ObtenerSubastaPorId(idPublicacion);
                Cliente? obtenerCliente = system.ObtenerClientePorId(idCliente);
                system.ProcesarOferta(obtenerCliente, unaSubasta, monto);

				HttpContext.Session.SetString("OfferSuccess", "La oferta ha sido realizada exitosamente."); 

                HttpContext.Session.SetString("OfferValue", monto.ToString());
            }
            catch (Exception ex)
            {
                HttpContext.Session.SetString("OfferError", ex.Message);
            }

            return RedirectToAction("Index", "OperationsResults");
        }

        public IActionResult HomeAdm()
		{
            Usuario? oneUser = null;
            int? userIdFromSession = HttpContext.Session.GetInt32("UserId");  // O también GetString("UserId") dependiendo de cómo guardes el id

            if (userIdFromSession.HasValue)  // Si el ID no se pasó, intentamos obtenerlo de la sesión
            {
                oneUser = system.ObtenerUsuarioPorId(userIdFromSession.Value);
            }
            else
            {
                //redirección login
            }
            string? rol = HttpContext.Session.GetString("Rol");
			int? userId = HttpContext.Session.GetInt32("UserId");
			if (oneUser != null && oneUser is Administrador && rol == "Administrador")
			{
				return View(system.ObtenerSubastas());
			}
			else
			{
				return RedirectToAction("Index", "ErrorCredentials");
			}
		}

	

		[HttpPost]
		public IActionResult CerrarSubasta(int idSubasta)
		{
			// Validar rol de usuario
			if (HttpContext.Session.GetString("Rol") != "Administrador")
			{
				return Redirect("/Login/Index");
			}

			// Validar ID del administrador
			int? idAdministrador = HttpContext.Session.GetInt32("UserId");
			if (idAdministrador == null)
			{
				ViewBag.Error = "No existe ningún administrador con dicha ID.";
				return View("HomeAdm", system.ObtenerSubastas()); // Recargar subastas
			}

			// Obtener la subasta y validar
			Subasta? unaSubasta = system.ObtenerSubastaPorId(idSubasta);
			if (unaSubasta == null)
			{
				ViewBag.Error = "No se encontró ninguna subasta con este ID.";
				return View("HomeAdm", system.ObtenerSubastas());
			}

			// Obtener la mejor oferta y validar
			Oferta? unaOferta = unaSubasta.ObtenerMejorOferta();
			if (unaOferta == null)
			{
				ViewBag.Error = "No se obtuvo ninguna oferta para esta subasta.";
				return View("HomeAdm", system.ObtenerSubastas());
			}

			// Obtener el cliente relacionado con la mejor oferta
			int idCliente = unaSubasta.ObtenerIdClienteMayorOferta(unaOferta.Monto);
			Cliente? unCliente = system.ObtenerClientePorId(idCliente);
			if (unCliente == null)
			{
				ViewBag.Error = "No se pudo obtener al cliente de la mejor oferta.";
				return View("HomeAdm", system.ObtenerSubastas());
			}

			// Obtener administrador y validar
			Administrador? unAdministrador = system.ObtenerAdministradorPorId(idAdministrador.Value);
			if (unAdministrador == null)
			{
				ViewBag.Error = "No se pudo encontrar al administrador.";
				return View("HomeAdm", system.ObtenerSubastas());
			}

			// Intentar cerrar la subasta
			try
			{
				unaSubasta.CerrarPublicacion(unAdministrador, unaOferta.Monto, unCliente);
				ViewBag.Mensaje = "Subasta cerrada con éxito.";
			}
			catch (Exception ex)
			{
				ViewBag.Error = ex.Message;
			}

			// Recargar la vista con las subastas actualizadas
			return View("HomeAdm", system.ObtenerSubastas());
		}

	}
}
