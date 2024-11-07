namespace Dominio
{
    public class Usuario
    {
        private static int _ultimoId = 0;
        private int _id;
        private string _nombre;
        private string _apellido;
        private string _email;
        private string _contrasenia;


        public int UltimoId
        {
            get { return _ultimoId; }

        }

        public int Id
        {
            get { return _id; }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string Contrasenia
        {
            get { return _contrasenia; }
            set { _contrasenia = value; }
        }

        public Usuario() { }

        public Usuario(string nombre, string apellido, string email, string contrasenia)
        {
            _ultimoId++;
            _id = _ultimoId;
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Contrasenia = contrasenia;
        }

        public void IniciarSesion() { }

        public override string ToString()
        {
            return $"Nombre del usuario: {Nombre} \n" +
                $"Apellido: {Apellido}\n" +
                $"Email: {Email}."; 
        }
    }
}
