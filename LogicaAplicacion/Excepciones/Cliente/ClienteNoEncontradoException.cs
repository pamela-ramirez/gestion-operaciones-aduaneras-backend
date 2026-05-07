using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteNoEncontradoException : ClaseExcepcion
    {
        public ClienteNoEncontradoException() : base("Cliente no encontrado.") { }
    }
}
