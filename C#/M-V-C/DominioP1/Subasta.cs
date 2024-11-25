
using DominioP1;

namespace Dominio
{
	public class Subasta : Publicacion, IValidable, IComparable<Subasta>
	{
		private List<Oferta> _listaOfertas;
		private float _precioInicial;
		private float _precioFinal;



		//PROPIEDADES... 

		public List<Oferta> ListaOfertas
		{
			get { return _listaOfertas; }
			set { _listaOfertas = value; }
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

		public int CompareTo(Subasta unaSubasta)
		{
			return this.FechaPublicacion.CompareTo(unaSubasta.FechaPublicacion);
		}

		public override void CerrarPublicacion(Usuario unUsuario, params object[] parametros)
		{
			if (parametros.Length == 2 && parametros[0] is float mayorOferta && parametros[1] is Cliente clienteOfertador)
			{
				if (Estado == EstadoPublicacion.ABIERTA)
				{

					_precioFinal = mayorOferta;
					clienteOfertador.SaldoDisponible -= decimal.Parse(mayorOferta.ToString());
					Estado = EstadoPublicacion.CERRADA;
					FechaFinalizacion = DateTime.Now;
					ClienteComprador = clienteOfertador; 
				}
				else
				{
					throw new Exception("No se puede finalizar una publicación cerrada.");
				}
			}
			else
			{
				throw new ArgumentException("Se requieren los parámetros 'mayorOferta' y 'clienteOfertador' para cerrar la subasta.");
			}
		}

		//MÉTODO PARA OBTENER EL USUARIO QUE REALIZÓ LA MAYOR OFERTA PARA LA SUBASTA.
		public int ObtenerIdClienteMayorOferta(float mayorOferta)
		{
			foreach (Oferta unaOferta in _listaOfertas)
			{
				if (unaOferta.Monto == mayorOferta)
				{
					return unaOferta.IdUsuarioOfertador();
				}
			}

			return -1;  
		}
	}
}