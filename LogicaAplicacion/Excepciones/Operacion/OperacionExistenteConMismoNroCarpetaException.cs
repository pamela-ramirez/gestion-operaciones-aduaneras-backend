using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Operacion
{
    public class OperacionExistenteConMismoNroCarpetaException : ClaseExcepcion
    {
        public OperacionExistenteConMismoNroCarpetaException() : base("Ya existe una operación con el mismo número de carpeta.") { }
    }
}
