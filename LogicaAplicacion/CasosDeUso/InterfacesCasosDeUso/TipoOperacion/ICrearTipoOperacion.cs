using Compartido.DTOs.TipoOperacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion
{
    public interface ICrearTipoOperacion
    {
        TipoOperacionListadoDTO Ejecutar(CrearTipoOperacionDTO dto);
    }
}
