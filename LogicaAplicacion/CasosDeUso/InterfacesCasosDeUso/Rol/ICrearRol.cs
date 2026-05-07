using Compartido.DTOs.Rol;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol
{
    public interface ICrearRol
    {
        //RolRespuestaDTO Ejecutar(CrearRolDTO dto);
        RolListadoDTO Ejecutar(RolDTO rolDTO);
    }
}
