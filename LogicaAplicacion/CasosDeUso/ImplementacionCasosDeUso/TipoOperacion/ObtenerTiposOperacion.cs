using Compartido.DTOs.TipoOperacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.TipoOperacion
{
    public class ObtenerTiposOperacion : IObtenerTiposOperacion
    {
        private readonly IRepositorioTipoOperacion _tipoOperacionRepo;

        public ObtenerTiposOperacion(IRepositorioTipoOperacion tipoOperacionRepo)
        {
            _tipoOperacionRepo = tipoOperacionRepo;
        }

        public IEnumerable<TipoOperacionListadoDTO> Ejecutar()
        {
            var tipos = _tipoOperacionRepo.FindAll();
            // Usamos el mapper para convertir cada entidad a DTO
            return TipoOperacionMapper.ToListaDTO(tipos);
        }
    }
}
