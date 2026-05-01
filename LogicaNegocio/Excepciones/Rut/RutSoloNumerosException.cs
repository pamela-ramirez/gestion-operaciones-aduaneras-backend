using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Rut
{
    public class RutSoloNumerosException : ClassException
    {
        public RutSoloNumerosException() : base("El RUT debe contener solo números (sin puntos ni guiones).") { }
    }
}
