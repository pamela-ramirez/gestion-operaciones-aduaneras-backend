using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioDespachante : IRepositorio<Despachante>
    {
        bool ExisteEmail(string email);
    }
}
