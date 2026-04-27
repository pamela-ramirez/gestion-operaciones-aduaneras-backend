using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones
{
    public class ClassException : Exception
    {
        public ClassException() { }

        public ClassException(string message) : base(message) { }

        public ClassException(string message, Exception innerException) : base(message, innerException) { }

    }
}
