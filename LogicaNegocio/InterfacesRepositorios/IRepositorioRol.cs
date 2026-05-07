using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRol : IRepositorio<Rol>
    {
        Rol FindByNombre(string nombreRol);

    }
}
