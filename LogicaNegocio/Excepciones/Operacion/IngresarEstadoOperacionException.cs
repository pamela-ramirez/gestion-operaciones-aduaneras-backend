using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class IngresarEstadoOperacionException : ClassException
    {
        public IngresarEstadoOperacionException() : base ("El estado es obligatorio.") { }
    }
}
