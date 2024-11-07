namespace Dominio
{
    public class Cliente : Usuario
    {
        private decimal _saldoDisponible;


        public decimal SaldoDisponible
        {
            get { return _saldoDisponible; }
        }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldoCliente) : base(nombre, apellido, email, contrasenia)
        {
            _saldoDisponible = saldoCliente;
        }

        public void RealizarOfertaSubasta() { }

        public void RealizarCompra() { }

        public override string ToString() 
        {
            return $"--------------------------------\n" +
                $"Nombre del cliente: {Nombre}\n" +
                $"Apellido del cliente: {Apellido}\n" +
                $"Email del cliente: {Email}\n" +
                $"Saldo disponible: {SaldoDisponible}.\n" +
                $"----------------------------------";
        }

        
 
    }
}
