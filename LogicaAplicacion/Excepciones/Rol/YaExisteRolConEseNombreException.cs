using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class YaExisteRolConEseNombreException : ClaseExcepcion
    {
        public YaExisteRolConEseNombreException() : base("Ya existe un rol con ese nombre.") { }
    }
}
