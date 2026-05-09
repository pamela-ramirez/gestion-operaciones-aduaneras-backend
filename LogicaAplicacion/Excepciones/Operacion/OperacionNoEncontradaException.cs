using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Operacion
{
    public class OperacionNoEncontradaException : ClaseExcepcion
    {
        public OperacionNoEncontradaException() : base("La operación solicitada no se encontró.")
        {
    }
}
