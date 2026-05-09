using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Despachante
{
    public class CodigoDespachanteExcesoCaracteresException : ClassException
    {
        public CodigoDespachanteExcesoCaracteresException()
            : base("El código del despachante no puede superar los 30 caracteres.") { }
    }
}
