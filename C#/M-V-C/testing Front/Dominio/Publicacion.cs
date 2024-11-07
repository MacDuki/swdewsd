
namespace Dominio

{
    public class Publicacion
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

        public static int S_ultimoId { get => s_ultimoId;  }
        public int Id { get => _id; }
        public string Nombre { get => _nombre; set => _nombre = value; }
        public EstadoPublicacion Estado { get => _estado; set => _estado = value; }
        public DateTime FechaPublicacion { get => _fechaPublicacion; set => _fechaPublicacion = value; }
        public List<Articulo> ListaArticulos { get => _listaArticulos; set => _listaArticulos = value; }
        public Cliente ClienteComprador { get => _clienteComprador; set => _clienteComprador = value; }
        public Usuario UsuarioFinaliza { get => _usuarioFinaliza; set => _usuarioFinaliza = value; }
        public DateTime FechaFinalizacion { get => _fechaFinalizacion; set => _fechaFinalizacion = value; }


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
        public Publicacion(string nombre, string tipoPublicacion, DateTime fechaPublicacion,DateTime fechaFinalizacion  )
        {
            _id = ++s_ultimoId;
            _nombre = nombre;
            _estado = EstadoPublicacion.ABIERTA;
            _fechaPublicacion = fechaPublicacion;
            _listaArticulos = ListaArticulos;
            _tipoPublicacion = tipoPublicacion;
            _fechaFinalizacion = fechaFinalizacion;
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
                throw new Exception("No se pueden agregar artículos a una publicación que no está ABIERTA.");
            }
        }
        public override string ToString()
        {
            return $"ID: {_id}, Nombre: {_nombre}, Tipo: {_tipoPublicacion}," +
                   $"Fecha de Publicación: {_fechaPublicacion:MM/dd/yyyy}, " +
                   $"Fecha de Finalización: {_fechaFinalizacion:MM/dd/yyyy}, Estado: {_estado}";
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

            public void FinalizarPublicacion(Usuario usuario)
            {
                if (_estado == EstadoPublicacion.ABIERTA)
                {
                    _estado = EstadoPublicacion.CERRADA;
                    _usuarioFinaliza = usuario;
                    _fechaFinalizacion = DateTime.Now;
                }
                else
                {
                throw new Exception("La publicación no está ABIERTA, por lo que no se puede finalizar.");
                }
            }
        }


       
}
