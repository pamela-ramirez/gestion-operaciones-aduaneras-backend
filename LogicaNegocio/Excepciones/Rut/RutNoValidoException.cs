using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rut
{
    public class RutNoValidoException : ClassException
    {
        public RutNoValidoException() : base("El RUT no es válido (fallo en dígito verificador).") { }
    }
}
