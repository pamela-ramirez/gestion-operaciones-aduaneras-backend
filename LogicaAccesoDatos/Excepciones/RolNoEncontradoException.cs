using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class RolNoEncontradoException : ClaseGenericaException
    {
        public RolNoEncontradoException() : base("El rol no ha sido encontrado.")
        {
        }
    }
}
