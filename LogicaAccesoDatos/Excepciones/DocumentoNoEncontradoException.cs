using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class DocumentoNoEncontradoException : ClaseGenericaException
    {
        public DocumentoNoEncontradoException() : base("El documento solicitado no se encontro.") { }
    }
}
