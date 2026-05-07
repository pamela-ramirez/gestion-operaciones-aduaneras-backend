using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteDireccionExcesoCaracteresException : ClaseExcepcion
    {
        public ClienteDireccionExcesoCaracteresException() : base("La dirección no puede superar 300 caracteres.") { }
    }
}
