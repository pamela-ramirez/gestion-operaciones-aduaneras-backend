using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteTelefonoVacioException : ClassException
    {
        public ClienteTelefonoVacioException() : base("El teléfono no puede estar vacío.") { }
    }
}
