
using System.Security.Cryptography;

namespace Dominio
{
    public class Subasta : Publicacion
    {
        private List<Oferta> _listaOfertas;
        private float _precioFinal;

       //constructor 
        public Subasta(string nombre, string tipoPublicacion, float precioInicial)
            : base(nombre, tipoPublicacion)
        {
            _listaOfertas = new List<Oferta>();
            _precioFinal = precioInicial;
        }

        //Constructor precarga
        public Subasta(string nombre, string tipoPublicacion, DateTime fechaPublicacion, DateTime fechaFinalizacion, float precioInicial)
    : base(nombre, tipoPublicacion, fechaPublicacion, fechaFinalizacion)
        {
            _listaOfertas = new List<Oferta>();
            _precioFinal = precioInicial;
        }

        // Método para realizar una oferta

        public void RealizarOferta(Cliente cliente, float monto, DateTime fecha)
        {
      
            Oferta nuevaOferta = new Oferta(cliente, monto, fecha);
            _listaOfertas.Add(nuevaOferta);

         
            _precioFinal = monto;
        }

    
        public Oferta ObtenerMejorOferta()
        {
            return _listaOfertas.OrderByDescending(oferta => oferta.Monto).FirstOrDefault();
        }

     
    }
}

