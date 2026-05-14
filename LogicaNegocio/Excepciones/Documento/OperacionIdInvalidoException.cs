using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Documento
{
    public class OperacionIdInvalidoException : ClassException
    {
        public OperacionIdInvalidoException() : base("El ID de la operación no es válido.")
        {
        }
    }
}
