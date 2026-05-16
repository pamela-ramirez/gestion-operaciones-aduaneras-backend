using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        Task<Usuario?> GetByEmail(string email);
        bool ExisteEmail(string email);
    }
}
