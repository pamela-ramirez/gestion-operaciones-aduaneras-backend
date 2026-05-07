using Compartido.DTOs.TipoOperacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion
{
    public interface IObtenerTiposOperacion
    {
        IEnumerable<TipoOperacionListadoDTO> Ejecutar();
    }
}
