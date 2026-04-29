using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class RolSinNombreException : ClassException
    {
        public RolSinNombreException() : base("El rol debe tener un nombre.") { }
    }
}
