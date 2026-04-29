using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class YaExisteRolConEseNombreException : ClassException
    {
        public YaExisteRolConEseNombreException() : base("Ya existe un rol con ese nombre.") { }
    }
}
