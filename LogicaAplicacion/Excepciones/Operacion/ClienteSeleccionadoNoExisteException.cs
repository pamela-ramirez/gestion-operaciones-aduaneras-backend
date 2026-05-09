using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Operacion
{
    public class ClienteSeleccionadoNoExisteException : ClaseExcepcion
    {
        public ClienteSeleccionadoNoExisteException() : base("El cliente seleccionado no existe.")
        {
        }
    }
}
