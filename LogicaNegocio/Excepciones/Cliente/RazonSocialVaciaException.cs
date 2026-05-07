using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Cliente
{
    public class RazonSocialVaciaException : ClassException
    {
        public RazonSocialVaciaException()  : base("La razón social no puede estar vacía.") { }
    }
}
