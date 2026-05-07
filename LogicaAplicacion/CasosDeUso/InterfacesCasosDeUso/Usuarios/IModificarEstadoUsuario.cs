using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IModificarEstadoUsuario
    {
        UsuarioLogueadoDTO Ejecutar(int idUsuario);
    }
}
