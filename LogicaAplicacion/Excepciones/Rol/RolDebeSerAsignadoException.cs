using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class RolDebeSerAsignadoException : ClaseExcepcion
    {
        public RolDebeSerAsignadoException() : base("Debe asignar un rol al usuario.")
        {
        }
    }
}
