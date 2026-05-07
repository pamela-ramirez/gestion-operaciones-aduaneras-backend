using Compartido.DTOs.Usuarios;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IUsuarioService
    {
        UsuarioListadoDTO ObtenerUsuarioPorId(int id);
        UsuarioListadoDTO ModificarUsuario(int id, ModificarUsuarioDTO dto);
        void EliminarUsuario(int id);
        IEnumerable<UsuarioListadoDTO> ObtenerUsuarios();
    }
}
