using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class TipoOperacionNoEncontradoException : ClaseGenericaException
    {
        public TipoOperacionNoEncontradoException() :base("Tipo de operación no encontrado."){ }
    }
}
