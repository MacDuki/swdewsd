
using DominioP1;

namespace Dominio

{
    public abstract class Publicacion : IValidable, IComparable<Publicacion>
    {
        public enum EstadoPublicacion
        {
            ABIERTA,
            CERRADA,
            CANCELADA
        }


        // Atributos privados
        private static int s_ultimoId = 0;
        private int _id;
        private string _nombre;
        private EstadoPublicacion _estado;
        private DateTime _fechaPublicacion;
        private List<Articulo> _listaArticulos;
        private Cliente _clienteComprador;
        private Usuario _usuarioFinaliza;
        private DateTime _fechaFinalizacion;
        private string _tipoPublicacion;

        public static int S_ultimoId { get => s_ultimoId; }
        public int Id { get => _id; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public EstadoPublicacion Estado { get => _estado; set => _estado = value; }
        public DateTime FechaPublicacion { get => _fechaPublicacion; set => _fechaPublicacion = value; }
        public List<Articulo> ListaArticulos { get => _listaArticulos; set => _listaArticulos = value; }
        public Cliente ClienteComprador { get => _clienteComprador; set => _clienteComprador = value; }
        public Usuario UsuarioFinaliza { get => _usuarioFinaliza; set => _usuarioFinaliza = value; }
        public DateTime FechaFinalizacion { get => _fechaFinalizacion; set => _fechaFinalizacion = value; }

        public string TipoPublicacion 
        {
            get { return _tipoPublicacion; }
            set { _tipoPublicacion = value; }
        }

        //CONSTRUCTOR

        public Publicacion() { } 

        // Constructor
        public Publicacion(string nombre, string tipoPublicacion)
        {
            _id = ++s_ultimoId;
            _nombre = nombre;
            _estado = EstadoPublicacion.ABIERTA;
            _fechaPublicacion = DateTime.Now;
            _listaArticulos = ListaArticulos;
            _tipoPublicacion = tipoPublicacion;
        }

		//Constructor de precargas 
		public Publicacion(string nombre, string tipoPublicacion, DateTime fechaPublicacion, DateTime? fechaFinalizacion = null)
		{
			_id = ++s_ultimoId;
			_nombre = nombre;
			_estado = EstadoPublicacion.ABIERTA;
			_fechaPublicacion = fechaPublicacion;
			_listaArticulos = new List<Articulo>();
			_tipoPublicacion = tipoPublicacion;

			if (fechaFinalizacion.HasValue)
			{
				_fechaFinalizacion = fechaFinalizacion.Value;
			}
			else
			{
			
				_fechaFinalizacion = DateTime.MaxValue; 
			}
		}


		// Métodos
		public void AgregarArticulo(Articulo articulo)
        {
            if (_estado == EstadoPublicacion.ABIERTA)
            {
                _listaArticulos.Add(articulo);
            }
            else
            {
                throw new Exception("No se pueden agregar artículos a una publicación que no esté ABIERTA.");
            }
        }
     
        public float CalcularPrecioTotal()
        {
            float total = 0;
            foreach (var articulo in _listaArticulos)
            {
                total += articulo.Precio;
            }
            return total;
        }

        public void Validar() 
        {
            ValidarNombre();
            ValidarTipoPublicacion();
            ValidarFechaFinalizacion(); 
        }

        private void ValidarNombre() 
        {
            if (Nombre.Length < 3) 
            {
                throw new Exception("Verifique que el nombre de la publicación esté compuesto por al menos tres caracteres."); 
            }
        }

        private void ValidarTipoPublicacion() 
        {
            if (TipoPublicacion.Length < 3)
            {
                throw new Exception("Verifique que el tipo de publiación este compuesto por al menos tres caracteres."); 
            }
        }

        private void ValidarFechaFinalizacion() 
        {
            if (FechaFinalizacion < DateTime.Now) 
            {
                throw new Exception("Verifique que la fecha de finalizaciön de la publicación sea posterior al día de hoy."); 
            }
        }

        //TIRAR UNA EXCEPCIÓN SI AL MOMENTO DE REALIZAR UNA OFERTA O REALIZAR UNA COMPRA, LA PUBLICACIÓN ESTÁ CERRADA. 
        public void PublicacionEstaAbierta(Publicacion unaPublicacion) 
        {
            if (unaPublicacion.Estado == EstadoPublicacion.CERRADA) 
            {
                if (unaPublicacion is Venta) 
                {
                    throw new Exception("No se puede procesar la compra porque la publicación está cerrada."); 
				}
                if (unaPublicacion is Subasta) 
                {
                    throw new Exception("No se puede procesar la oferta porque la publicación está cerrada."); 
                }
			}
        }

		//MÉTODO PARA CERRAR UNA PUBLICACIÓN. 
		public abstract void CerrarPublicacion(Usuario unUsuario, params object[] parametros);

		//MÉTODO COMPARE TO PARA ORDENAR EL LISTADO DE PUBLICACIONES SEGÚN LA FECHA DE PUBLICACIÓN. 
		public int CompareTo(Publicacion unaPublicacion)
        {
            return this._fechaPublicacion.CompareTo(unaPublicacion.FechaPublicacion);
        }

        // Método para verificar estado. 
		public void ActualizarEstado()
		{
		if (DateTime.Now > _fechaFinalizacion)
			{
				_estado = EstadoPublicacion.CERRADA;
			}
			else
			{
				_estado = EstadoPublicacion.ABIERTA;
			}
		}
	}



}
