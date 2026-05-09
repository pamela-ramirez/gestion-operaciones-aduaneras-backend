using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class FechaRegistroOperacionInvalidaException : ClassException
    {
        public FechaRegistroOperacionInvalidaException() : base("La fecha de registro de la operación es incorrecta.")
        {
        }
    }
}
