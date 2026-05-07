using Compartido.DTOs.Auth;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface ILogin
    {
        Task<LoginResponseDTO> Ejecutar(LoginDTO dto);
    }
}
