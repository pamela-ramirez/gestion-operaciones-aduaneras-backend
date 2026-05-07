using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IJwtService
    {
        string GenerarToken(Usuario usuario);
    }
}
