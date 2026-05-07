using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioCliente : IRepositorio<Cliente>
    {
        bool ExisteRut(string rut, int? excluirClienteId = null);
        bool TieneOperacionesActivas(int ClienteId);
        Cliente FindByRut(string rut);

    }
}
