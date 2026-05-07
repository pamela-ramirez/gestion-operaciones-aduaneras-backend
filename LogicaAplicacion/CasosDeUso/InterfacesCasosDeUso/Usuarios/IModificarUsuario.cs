using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IModificarUsuario
    {
        UsuarioListadoDTO Ejecutar(int id, ModificarUsuarioDTO dto);
    }
}