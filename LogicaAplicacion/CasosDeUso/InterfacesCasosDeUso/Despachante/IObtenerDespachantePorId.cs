using Compartido.DTOs.Despachante;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante
{
    public interface IObtenerDespachantePorId
    {
        DespachanteDTO Ejecutar(int id);
    }
}
