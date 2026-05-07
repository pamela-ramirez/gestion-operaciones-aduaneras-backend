using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class RolSinNombreException : ClaseExcepcion
    {
        public RolSinNombreException() : base("El rol debe tener un nombre.") { }
    }
}
