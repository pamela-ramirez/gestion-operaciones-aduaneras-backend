using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Documento
{
    public class FormatoDocumentoInvalidoException : ClassException
    {
        public FormatoDocumentoInvalidoException() : base("El formato del documento es inválido.")
        {
        }
    }
}
