using Compartido.DTOs.TipoOperacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.TipoOperacion
{
    public class ObtenerTipoOperacionPorId : IObtenerTipoOperacionPorId
    {
        private readonly IRepositorioTipoOperacion _tipoOperacionRepo;

        public ObtenerTipoOperacionPorId(IRepositorioTipoOperacion tipoOperacionRepo)
        {
            _tipoOperacionRepo = tipoOperacionRepo;
        }

        public TipoOperacionListadoDTO Ejecutar(int id)
        {
            var tipoOperacion = _tipoOperacionRepo.FindById(id);
            if (tipoOperacion == null)
            {
                throw new Exception($"No se encontró el tipo de operación con ID {id}");
            }

            return TipoOperacionMapper.ToDTO(tipoOperacion);
        }
    }
}
