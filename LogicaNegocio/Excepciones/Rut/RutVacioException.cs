using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rut
{
    public class RutVacioException : ClassException
    {
        public RutVacioException() : base("El RUT no puede estar vacío.") { }
    }
}
