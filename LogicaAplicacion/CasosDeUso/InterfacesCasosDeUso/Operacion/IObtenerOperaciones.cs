using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IObtenerOperaciones
    {
        IEnumerable<OperacionListadoDTO> Ejecutar(
           int? clienteId,
           int? tipoOperacionId,
           string? estado,
           DateTime? fechaDesde,
           DateTime? fechaHasta);
    }
}
