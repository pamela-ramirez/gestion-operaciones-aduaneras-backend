using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class RolExcesoCaracteresException : ClassException
    {
        public RolExcesoCaracteresException() : base("El nombre del rol no puede superar 100 caracteres.") { }
    }
}
