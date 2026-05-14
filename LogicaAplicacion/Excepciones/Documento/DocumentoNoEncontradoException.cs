using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Documento
{
    public class DocumentoNoEncontradoException : ClaseExcepcion
    {
        public DocumentoNoEncontradoException()
            : base("No se encontró el documento.")
        {
        }
    }
}
