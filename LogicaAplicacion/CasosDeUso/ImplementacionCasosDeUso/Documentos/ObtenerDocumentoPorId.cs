using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Documento;
using LogicaAplicacion.Excepciones.Documento;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Documentos
{
    public class ObtenerDocumentoPorId : IObtenerDocumentoPorId
    {
        private readonly IRepositorioDocumento _repositorioDocumento;

        public ObtenerDocumentoPorId(IRepositorioDocumento repositorioDocumento)
        {
            _repositorioDocumento = repositorioDocumento;
        }
        public DocumentoRespuestaDTO Ejecutar(int id)
        {
             var documento = _repositorioDocumento.FindById(id);
            if (documento == null)
            {
                throw new DocumentoNoEncontradoException();
            }
            return DocumentoMapper.ToDTO(documento);
        }
    }
}
