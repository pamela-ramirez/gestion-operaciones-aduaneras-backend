using LogicaNegocio.Excepciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class RolExcesoCaracteresException : ClaseExcepcion
    {
        public RolExcesoCaracteresException() : base("El nombre del rol no puede superar 100 caracteres.") { }
    }
}
