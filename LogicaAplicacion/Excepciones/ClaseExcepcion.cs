using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones
{
    public class ClaseExcepcion: Exception
    {
        public ClaseExcepcion() { }

        public ClaseExcepcion(string message) : base(message) { }

        public ClaseExcepcion(string message, Exception innerException) : base(message, innerException) { }

    }
}
