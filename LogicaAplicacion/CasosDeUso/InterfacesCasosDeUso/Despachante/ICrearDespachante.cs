using Compartido.DTOs.Despachante;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante
{
    public interface ICrearDespachante
    {
        CrearDespachanteRespuestaDTO Ejecutar(CrearDespachanteDTO dto);
    }
}
