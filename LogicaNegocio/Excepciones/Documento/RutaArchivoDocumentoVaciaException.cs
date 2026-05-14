using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Documento
{
    public class RutaArchivoDocumentoVaciaException: ClassException
    {
        public RutaArchivoDocumentoVaciaException() : base("La ruta del archivo no puede estar vacía.")
        {
        }
    }
}
