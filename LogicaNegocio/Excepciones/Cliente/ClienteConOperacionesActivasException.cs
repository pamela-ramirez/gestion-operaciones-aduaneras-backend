using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteConOperacionesActivasException : ClassException
    {
        public ClienteConOperacionesActivasException() : base("El cliente no puede ser eliminado porque tiene operaciones activas.") { }
    }
}
