using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteNoEncontradoException : ClassException
    {
        public ClienteNoEncontradoException() : base("Cliente no encontrado.") { }
    }
}
