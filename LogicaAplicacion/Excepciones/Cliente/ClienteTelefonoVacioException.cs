using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Cliente
{
    public class ClienteTelefonoVacioException : ClaseExcepcion
    {
        public ClienteTelefonoVacioException() : base("El teléfono no puede estar vacío.") { }
    }
}
