using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
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
            // Traemos todas y filtramos en memoria.
            // Para volúmenes grandes se puede mejorar con consultas LINQ directas al contexto.
            var operaciones = _operacionRepo.FindAll();

            if (clienteId.HasValue)
                operaciones = operaciones.Where(o => o.ClienteId == clienteId.Value);

            if (tipoOperacionId.HasValue)
                operaciones = operaciones.Where(o => o.TipoOperacionId == tipoOperacionId.Value);

            if (!string.IsNullOrWhiteSpace(estado) &&
                Enum.TryParse<EstadoOperacion>(estado, out var estadoEnum))
                operaciones = operaciones.Where(o => o.Estado == estadoEnum);

            if (fechaDesde.HasValue)
                operaciones = operaciones.Where(o => o.FechaRegistro >= fechaDesde.Value);

            if (fechaHasta.HasValue)
                operaciones = operaciones.Where(o => o.FechaRegistro <= fechaHasta.Value);

            return operaciones
                .Select(OperacionMapper.ToListadoDTO)
                .ToList();
        }
    }
}
