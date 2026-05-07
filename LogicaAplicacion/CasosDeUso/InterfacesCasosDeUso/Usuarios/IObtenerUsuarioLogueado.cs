using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IObtenerUsuarioLogueado
    {
        Task<UsuarioLogueadoDTO> Ejecutar(int id);
    }
}
