using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class RolDatosIncorrectosException : ClaseExcepcion
    {
        public RolDatosIncorrectosException() : base("Los datos recibidos no son correctos.") { }
    }
}
