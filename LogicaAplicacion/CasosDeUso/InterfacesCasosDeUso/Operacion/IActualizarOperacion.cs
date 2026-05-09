using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IActualizarOperacion
    {
        OperacionRespuestaDTO Ejecutar(int operacionId, ActualizarDatosAduanerosDTO dto);
    }
}
