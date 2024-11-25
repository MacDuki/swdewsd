using DominioP1;

namespace Dominio
{
    public class Venta : Publicacion, IValidable
    {

        public bool _esOfertaRelampago;
        public float _precioVenta;

        public bool EsOfertaRelampago
        {
            get { return _esOfertaRelampago; }
            set { _esOfertaRelampago = value; }
        }

        public float PrecioVenta
        {
            get { return _precioVenta; }
            set { _precioVenta = value; }
        }


        public Venta(string nombre, string tipoPublicacion, bool esOfertaRelampago, float precioVenta)
            : base(nombre, tipoPublicacion)
        {
            EsOfertaRelampago = esOfertaRelampago;
            PrecioVenta = precioVenta;
        }
        //Constructor precarga
        public Venta(string nombre, string tipoPublicacion, DateTime fechaPublicacion, DateTime? fechaFinalizacion, bool esOfertaRelampago, float precioVenta)
       : base(nombre, tipoPublicacion, fechaPublicacion, fechaFinalizacion)
        {
            // Si la fecha de finalización es null, la venta permanece abierta
            if (fechaFinalizacion == null)
            {
                Estado = EstadoPublicacion.ABIERTA;
            }
            else
            {
                Estado = EstadoPublicacion.CERRADA;
            }

            EsOfertaRelampago = esOfertaRelampago;
            PrecioVenta = precioVenta;
        }


        private void ValidarPrecioVenta()
        {
            if (PrecioVenta < 0)
            {
                throw new Exception("Verifique que el precio de la venta, sea mayor a 0.");
            }
        }

        public float ObtenerPrecio()
        {
            if (EsOfertaRelampago)
            {
                return (PrecioVenta * 0.80f); // Aplica descuento solo al mostrar para que no acumule descuentos al recargar página.
            }
            return PrecioVenta;
        }


        public override void CerrarPublicacion(Usuario unUsuario, params object[] parametros)
        {
            // En Venta no necesitamos los parámetros adicionales
            if (Estado == EstadoPublicacion.ABIERTA)
            {
                Estado = EstadoPublicacion.CERRADA;
                FechaFinalizacion = DateTime.Now;
                UsuarioFinaliza = unUsuario;
                ClienteComprador = unUsuario as Cliente; 
            }
            else
            {
                throw new Exception("No se puede finalizar una publicación cerrada.");
            }
        }
    }
}