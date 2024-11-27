using DominioP1;

namespace Dominio
{
    public class Usuario : IValidable
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


        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia(); 
        }

        private void ValidarNombre() 
        {
            if (Nombre.Length < 3) 
            {
                throw new Exception("Verifique que el nombre del usuario esté compuesto por lo menos por tres caracteres."); 
            }
        }

        private void ValidarApellido() 
        {
            if (Apellido.Length < 3) 
            {
                throw new Exception("Verifique que el apellido del usuario esté compuesto por lo menos por tres caracteres.");
            }
        }

        private void ValidarContrasenia() 
        {
            if (Contrasenia.Length < 6) 
            {
                throw new Exception("La contraseña debe estar compuesta por un mínimo de 6 caracteres.");  
            }
        }

		public override bool Equals(object? obj)
		{
            return obj is Usuario unUsuario && unUsuario._email == Email; 
		}

	}
}
