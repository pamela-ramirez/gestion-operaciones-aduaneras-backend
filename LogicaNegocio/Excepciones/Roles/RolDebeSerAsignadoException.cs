using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class RolDebeSerAsignadoException : ClassException
    {
        public RolDebeSerAsignadoException() : base("Debe asignar un rol al usuario.")
        {
        }
    }
}
