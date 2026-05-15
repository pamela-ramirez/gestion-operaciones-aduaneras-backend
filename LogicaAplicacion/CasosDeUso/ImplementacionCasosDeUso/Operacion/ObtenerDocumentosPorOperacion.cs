using Compartido.DTOs.Documento;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ObtenerDocumentosPorOperacion : IObtenerDocumentosPorOperacion
    {
        private readonly IRepositorioOperacion _repositorioOperacion;
        public ObtenerDocumentosPorOperacion(IRepositorioOperacion repositorioOperacion)
        {
            _repositorioOperacion = repositorioOperacion;
        }
        public IEnumerable<DocumentoRespuestaDTO> Ejecutar(int idOperacion)
        {
            var operacion = _repositorioOperacion.FindById(idOperacion);
            if (operacion == null)
                throw new OperacionNoEncontradaException();
            return DocumentoMapper.ToListadoDTO(operacion.Documentos);
        }
    }
}
