using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IFinalizarOperacion
    {
        OperacionRespuestaDTO Ejecutar(int operacionId);
    }
}
