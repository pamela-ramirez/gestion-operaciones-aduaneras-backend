using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IActualizarDatosAduaneros
    {
        OperacionRespuestaDTO Ejecutar(int operacionId, ActualizarDatosAduanerosDTO dto);
    }
}
