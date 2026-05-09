using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    internal class OperacionNoEncontradaException : ClaseGenericaException
    {
        public OperacionNoEncontradaException() : base("La operación solicitada no se encontró.")
        {
        }
    }
}
