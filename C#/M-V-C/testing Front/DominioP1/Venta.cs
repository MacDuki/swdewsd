using DominioP1;

namespace Dominio
{
    public class Venta : Publicacion, IValidable
    {
        // NO DECLARO NI ULTIMO ID NI ID, PUESTO QUE LOS HEREDA DE LA CLASE PUBLICACIÓN.

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
        public Venta(string nombre, string tipoPublicacion, DateTime fechaPublicacion,  DateTime fechaFinalizacion, bool esOfertaRelampago, float precioVenta)
    : base(nombre, tipoPublicacion, fechaPublicacion, fechaFinalizacion)
        {
            EsOfertaRelampago = esOfertaRelampago;
            PrecioVenta = precioVenta;
        }

        public void Validar() 
        {
            ValidarPrecioVenta(); 
        }

        private void ValidarPrecioVenta() 
        {
            if (PrecioVenta < 0) 
            {
                throw new Exception("Verifique que el precio de la venta, sea mayor a 0.");
            }
        }

        public float AplicarDescuento()
        {
            float descuento = 0.20f;
            PrecioVenta *= (1 - descuento);
            return PrecioVenta;
        }
    }
}
