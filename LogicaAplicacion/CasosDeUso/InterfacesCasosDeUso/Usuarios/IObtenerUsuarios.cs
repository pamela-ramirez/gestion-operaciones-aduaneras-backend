using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IObtenerUsuarios
    {
        IEnumerable<UsuarioListadoDTO> Ejecutar();
    }
}
