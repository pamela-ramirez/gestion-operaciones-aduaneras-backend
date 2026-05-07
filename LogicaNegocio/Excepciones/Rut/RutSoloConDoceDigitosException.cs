using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rut
{
    public class RutSoloConDoceDigitosException : ClassException
    {
        public RutSoloConDoceDigitosException() : base("El RUT debe tener exactamente 12 dígitos.") { }
    }
}
