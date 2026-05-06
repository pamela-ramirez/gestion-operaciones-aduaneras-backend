using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class ClienteSeleccionadoInvalidoException : ClassException
    {
        public ClienteSeleccionadoInvalidoException() : base("Debe seleccionar un cliente válido.") { }
    }
}
