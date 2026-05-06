using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteExistenteConIgualRutException : ClaseExcepcion
    {
        public ClienteExistenteConIgualRutException() : base("Ya existe un cliente con ese RUT.") { }
    }
}
