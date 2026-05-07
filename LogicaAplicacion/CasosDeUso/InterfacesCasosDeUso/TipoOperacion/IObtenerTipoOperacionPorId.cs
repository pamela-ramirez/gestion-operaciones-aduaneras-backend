using Compartido.DTOs.TipoOperacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion
{
    public interface IObtenerTipoOperacionPorId
    {
        TipoOperacionListadoDTO Ejecutar(int id);
    }
}
