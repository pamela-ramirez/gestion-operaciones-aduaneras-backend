using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class ClaseGenericaException : Exception
    {
        public ClaseGenericaException() { }

        public ClaseGenericaException(string message) : base(message) { }

        public ClaseGenericaException(string message, Exception innerException) : base(message, innerException) { }
    }
}
