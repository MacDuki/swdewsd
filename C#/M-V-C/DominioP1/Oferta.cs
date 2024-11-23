namespace Dominio
{
    public class Oferta
    {
        //CREACIÓN DE LOS ATRIBUTOS. 
        private static int s_ultimoId;
        private int _id; 
        private Cliente _usuarioOfertador;
        private float _monto;
        private DateTime _fechaOferta;

        //CREACIÓN DE LAS PROPIEDADES. 
        public int Id 
        {
            get { return _id;  }
        }
    
        public Cliente UsuarioOfertador
        {
            get { return _usuarioOfertador; }
        }

        public float Monto
        {
            get { return _monto; }
            set { _monto = value; }
        }

        public DateTime FechaOferta
        {
            get { return _fechaOferta; }
            set { _fechaOferta = value; }
        }

        //DECLARACIÓN DE CONSTRUCTORES.

        public Oferta() { }


        public Oferta(Cliente usuarioOfertador, float monto, DateTime fechaOferta)
        {
            s_ultimoId++;
            _id = s_ultimoId; 
            _usuarioOfertador = usuarioOfertador;
            Monto = monto;
            FechaOferta = fechaOferta;
        }

        public void RegistrarOferta(Cliente usuario, float monto)
        {
            if (usuario == null)
            {
                throw new Exception("El cliente debe existir.");
            }
            if (monto < 0)
            {
                throw new Exception("El monto de la oferta debe ser un valor numérico positivo.");
            }
            else
            {
                _usuarioOfertador = usuario;
                Monto = monto;
                FechaOferta = DateTime.Now;

            }
        }
    }
}