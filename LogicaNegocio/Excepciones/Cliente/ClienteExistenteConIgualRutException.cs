using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteExistenteConIgualRutException : ClassException
    {
        public ClienteExistenteConIgualRutException() : base("Ya existe un cliente con ese RUT.") { }
    }
}
