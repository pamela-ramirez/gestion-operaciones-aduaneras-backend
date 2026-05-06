using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class NumConocimientoInvalidoException : ClassException
    {
        public NumConocimientoInvalidoException() :base("Número de conocimiento inválido.") { }
    }
}
