using DominioP1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Administrador : Usuario, IValidable
    {

        public void CerrarSubasta() { }

        public void FinalizarVenta() { }

        public Administrador() { }

        public Administrador(string nombre, string apellido, string email, string contrasenia) : base (nombre, apellido, email, contrasenia){ }
        public override string ToString() 
        {
            return $"-------------------------------\n" +
                $"Nombre del administrador: {Nombre}\n" +
                $"Apellido del administrador: {Apellido}\n" +
                $"Email del administrador: {Email}.\n" +
                $"-------------------------------";
        }

    }
}
