using Compartido.DTOs.Rol;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol
{
    public interface IObtenerRoles
    {
        //IEnumerable<RolRespuestaDTO> Ejecutar();
        IEnumerable<RolListadoDTO> Ejecutar();
    }
}
