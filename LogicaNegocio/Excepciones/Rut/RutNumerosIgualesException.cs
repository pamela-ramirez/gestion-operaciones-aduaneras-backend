using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rut
{
    public class RutNumerosIgualesException : ClassException
    {
        public RutNumerosIgualesException() : base("El RUT no puede tener todos los dígitos iguales.")
        {
        }
    }
}
