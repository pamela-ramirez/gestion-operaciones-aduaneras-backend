using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IObtenerOperacionPorId
    {
        OperacionRespuestaDTO Ejecutar(int operacionId);
    }
}
