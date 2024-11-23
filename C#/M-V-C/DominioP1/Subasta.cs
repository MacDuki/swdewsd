
using DominioP1;
using System.Security.Cryptography;

namespace Dominio
{
	public class Subasta : Publicacion, IValidable
	{
		private List<Oferta> _listaOfertas;
		private float _precioInicial;
		private float _precioFinal;



		//PROPIEDADES... 

		public List<Oferta> ListaOfertas
		{
			get { return _listaOfertas; }
		}

		public float PrecioInicial
		{
			get { return _precioInicial; }
			set { _precioInicial = value; }
		}

		public float PrecioFinal
		{
			get { return _precioFinal; }
			set { _precioFinal = value; }
		}


		//constructor 
		public Subasta(string nombre, string tipoPublicacion, float precioInicial)
			: base(nombre, tipoPublicacion)
		{
			_listaOfertas = new List<Oferta>();
			_precioFinal = precioInicial;
		}

		//Constructor precarga
		public Subasta(string nombre, string tipoPublicacion, DateTime fechaPublicacion, DateTime? fechaFinalizacion = null, float precioInicial = 0f)
		: base(nombre, tipoPublicacion, fechaPublicacion, fechaFinalizacion)
		{
			_listaOfertas = new List<Oferta>();
			_precioFinal = precioInicial;

			if (!fechaFinalizacion.HasValue)
			{
				// Si no se proporciona fecha de finalización, se asegura que la subasta permanezca abierta.
				this.Estado = EstadoPublicacion.ABIERTA;
			}
		}


	

		// Método para realizar una oferta

		public void RealizarOferta(Cliente cliente, float monto, DateTime fecha)
		{

			Oferta nuevaOferta = new Oferta(cliente, monto, fecha);
			_listaOfertas.Add(nuevaOferta);


			_precioFinal = monto;
		}

		public void Validar()
		{
			ValidarPrecioInicial();
			ValidarPrecioFinal();
		}

		private void ValidarPrecioInicial()
		{
			if (PrecioInicial < 0)
			{
				throw new Exception("Verifique que el precio inicial de la subasta sea un número mayor a 0.");
			}
		}

		private void ValidarPrecioFinal()
		{
			if (PrecioInicial < 0)
			{
				throw new Exception("Verifique que el precio final de la subasta sea mayor a 0.");
			}
		}

		public Oferta ObtenerMejorOferta()
		{
			return _listaOfertas.OrderByDescending(oferta => oferta.Monto).FirstOrDefault();
		}


		public override bool Equals(object? obj)
		{
			return obj is Subasta unaSubasta && unaSubasta.Id == Id;
		}
	}
}