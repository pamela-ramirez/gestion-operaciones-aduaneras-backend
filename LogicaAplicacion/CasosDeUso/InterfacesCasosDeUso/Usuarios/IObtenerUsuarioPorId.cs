using Compartido.DTOs.Usuarios;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IObtenerUsuarioPorId
    {
        UsuarioListadoDTO Ejecutar(int id);
    }
}
