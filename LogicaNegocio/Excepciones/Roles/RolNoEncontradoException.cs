using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class RolNoEncontradoException : ClassException
    {
        public RolNoEncontradoException() : base("Rol no encontrado.") { }
    }
}
