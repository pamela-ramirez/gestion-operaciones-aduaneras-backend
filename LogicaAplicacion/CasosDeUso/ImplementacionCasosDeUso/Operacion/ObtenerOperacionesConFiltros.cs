using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;


namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ObtenerOperacionesConFiltros : IObtenerOperacionesConFiltros
    {
        private readonly IRepositorioOperacion _operacionRepo;

        public ObtenerOperacionesConFiltros(IRepositorioOperacion operacionRepo)
        {
            _operacionRepo = operacionRepo;
        }

        public IEnumerable<OperacionListadoDTO> Ejecutar(
            int? clienteId,
            int? tipoOperacionId,
            string? estado,
            DateTime? fechaDesde,
            DateTime? fechaHasta)
        {
            if (fechaDesde.HasValue && fechaHasta.HasValue && fechaDesde > fechaHasta)
                throw new FechasIntercambiadasException();

            var operaciones = _operacionRepo.FindConFiltros(
                clienteId, tipoOperacionId, estado, fechaDesde, fechaHasta);

            return operaciones
                .Select(OperacionMapper.ToListadoDTO)
                .ToList();
        }
    }
}
