﻿using DominioP1;

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

        //MÉTODO PARA VALIDAR QUE EL USUARIO TENGA SALDO SUFICIENTE PARA REALIZAR LA COMPRA O REALIZAR LA OFERTA. 
        public void ValidarSaldoSuficiente(decimal montoPublicacion) 
        {
            if (montoPublicacion > SaldoDisponible)
            {
                throw new Exception("El usuario no tiene saldo suficiente para realizar esta oferta o compra.");
            }
            else 
            {
                SaldoDisponible -= montoPublicacion; 
            }
        }
    }
}
