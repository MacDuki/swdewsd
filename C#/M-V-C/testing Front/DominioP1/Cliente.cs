using DominioP1;

namespace Dominio
{
    public class Cliente : Usuario, IValidable
    {
        private decimal _saldoDisponible;


        public decimal SaldoDisponible
        {
            get { return _saldoDisponible; }
            set { _saldoDisponible = value; }
        }

        public Cliente() { }

        public Cliente(string nombre, string apellido, string email, string contrasenia, decimal saldoCliente) : base(nombre, apellido, email, contrasenia)
        {
            _saldoDisponible = 0;
        }

        public void RealizarOfertaSubasta() { }

        public void RealizarCompra() { }

        public void CargarSaldo(decimal saldo)
        {
            if (saldo < 0)
            {
                throw new Exception("Verifique que el saldo ingresado sea mayor a 0.");
            }
            else 
            {
            SaldoDisponible += saldo;
            }
        }

        public override string ToString()
        {
            return $"--------------------------------\n" +
                $"Nombre del cliente: {Nombre}\n" +
                $"Apellido del cliente: {Apellido}\n" +
                $"Email del cliente: {Email}\n" +
                $"Saldo disponible: {SaldoDisponible}.\n" +
                $"----------------------------------";
        }

        public void Validar()
        {
            ValidarSaldo();
        }


        private void ValidarSaldo()
        {
            if (SaldoDisponible < 0)
            {
                throw new Exception("Verifique que el saldo del cliente sea mayor a 0.");
            }
        }
    }
}
