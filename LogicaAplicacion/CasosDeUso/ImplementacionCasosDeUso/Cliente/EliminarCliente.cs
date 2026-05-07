using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class EliminarCliente : IEliminarCliente
    {

        private readonly IRepositorioCliente _clienteRepo;

        public EliminarCliente(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public void Ejecutar(int id)
        {
            _clienteRepo.Delete(id);
        }
    }
}
