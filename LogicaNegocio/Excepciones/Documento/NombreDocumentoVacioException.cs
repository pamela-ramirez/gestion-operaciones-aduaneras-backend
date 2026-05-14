using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Documento
{
    public class NombreDocumentoVacioException: ClassException
    {
        public NombreDocumentoVacioException() : base("El nombre del documento no puede estar vacío.")
        {
        }
    }
}
