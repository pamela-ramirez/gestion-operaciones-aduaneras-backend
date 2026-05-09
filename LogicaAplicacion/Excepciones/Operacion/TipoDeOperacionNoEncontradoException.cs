using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Operacion
{
    public class TipoDeOperacionNoEncontradoException : ClaseExcepcion
    {
        public TipoDeOperacionNoEncontradoException() : base("El tipo de operación seleccionado no es válido.") { }
    }
}
