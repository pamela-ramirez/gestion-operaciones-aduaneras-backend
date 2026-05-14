using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Documento
{
    public class FormatoNoPermitidoException : ClaseExcepcion
    {
        public FormatoNoPermitidoException(string extension)
            : base($"Formato no permitido: {extension}. Solo se aceptan PDF, JPG, PNG.")
        {
        }
    }
}
