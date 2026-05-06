using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class NroDuaVacioOperacionException : ClassException
    {
        public NroDuaVacioOperacionException() : base ("El número de DUA no puede estar nulo o vacío.") { }
    }
}
