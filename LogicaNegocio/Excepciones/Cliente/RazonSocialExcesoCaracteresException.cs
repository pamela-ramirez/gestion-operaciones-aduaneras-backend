using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class RazonSocialExcesoCaracteresException : ClassException
    {
        public RazonSocialExcesoCaracteresException()
            : base("La razón social no puede superar 200 caracteres.") { }
    }
}
