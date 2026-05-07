using Compartido.DTOs.Operacion;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface ICrearOperacion
    {
        OperacionRespuestaDTO Ejecutar(CrearOperacionDTO dto);
    }
}
