using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class FechaCreacionInvalidaException: ClassException
    {
        public FechaCreacionInvalidaException() : base("La fecha de creación es inválida.")
        {
        }
    }
}
