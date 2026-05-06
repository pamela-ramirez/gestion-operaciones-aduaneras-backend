
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteConOperacionesActivasException : ClaseExcepcion
    {
        public ClienteConOperacionesActivasException() : base("El cliente no puede ser eliminado porque tiene operaciones activas.") { }
    }
}
