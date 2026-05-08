using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class RazonSocialMinimaCaracteresException : ClassException
    {
        public RazonSocialMinimaCaracteresException()
            : base("La razón social debe tener al menos 2 caracteres.") { }
    }
}
