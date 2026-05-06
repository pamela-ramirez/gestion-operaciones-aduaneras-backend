using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class SeleccionarTipoOperacionException : ClassException
    {
        public SeleccionarTipoOperacionException() : base("Debe seleccionar un tipo de operación.") {
    }
}
