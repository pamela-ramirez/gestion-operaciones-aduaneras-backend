using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteTelefonoMasVeinteCaracteresException : ClaseExcepcion
    {
        public ClienteTelefonoMasVeinteCaracteresException() : base("El teléfono no puede superar 20 caracteres.") { }
    }
}
