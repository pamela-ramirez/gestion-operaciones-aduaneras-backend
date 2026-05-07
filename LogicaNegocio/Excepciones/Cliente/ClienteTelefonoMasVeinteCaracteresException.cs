using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteTelefonoMasVeinteCaracteresException : ClassException
    {
        public ClienteTelefonoMasVeinteCaracteresException() : base("El teléfono no puede superar 20 caracteres.") { }
    }
}
