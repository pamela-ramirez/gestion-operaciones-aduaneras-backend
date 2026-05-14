using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Documento
{
    public interface IObtenerDocumentoPorId
    {
        DocumentoRespuestaDTO Ejecutar(int id);
    }
}
