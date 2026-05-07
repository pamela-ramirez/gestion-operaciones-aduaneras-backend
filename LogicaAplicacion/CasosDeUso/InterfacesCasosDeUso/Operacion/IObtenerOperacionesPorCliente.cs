using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IObtenerOperacionesPorCliente
    {
        IEnumerable<OperacionListadoDTO> Ejecutar(int clienteId);
    }
}
