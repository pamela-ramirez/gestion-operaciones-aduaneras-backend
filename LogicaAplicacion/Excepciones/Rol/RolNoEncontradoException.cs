using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class RolNoEncontradoException : ClaseExcepcion
    {
        public RolNoEncontradoException() : base("Rol no encontrado.") { }
    }
}
