using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class DocumentoMapper
    {
        public static DocumentoRespuestaDTO ToDTO(Documento documento)
        {
            return new DocumentoRespuestaDTO
            {
                Id = documento.Id,
                Nombre = documento.Nombre,
                Formato = documento.Formato.ToString(), // convierte enum a string
                FechaCarga = documento.FechaCarga,
                OperacionId = documento.OperacionId
            };
        }

        public static IEnumerable<DocumentoRespuestaDTO> ToListadoDTO(IEnumerable<Documento> documentos)
        {
            return documentos.Select(d => ToDTO(d)).ToList();
        }
    }
}
