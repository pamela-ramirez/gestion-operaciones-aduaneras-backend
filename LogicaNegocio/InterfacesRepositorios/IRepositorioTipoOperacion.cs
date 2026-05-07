using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioTipoOperacion : IRepositorio<TipoOperacion>
    {
        TipoOperacion FindByDescripcion(string descripcion);
    }
}
