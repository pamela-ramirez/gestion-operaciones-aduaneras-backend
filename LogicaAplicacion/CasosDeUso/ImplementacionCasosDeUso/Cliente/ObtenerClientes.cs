using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class ObtenerClientes : IObtenerClientes
    {

        private readonly IRepositorioCliente _clienteRepo;

        public ObtenerClientes(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public IEnumerable<ClienteDTO> Ejecutar()
        {
            var clientes = _clienteRepo.FindAll();
            return clientes.Select(c => ClienteMapper.ToClienteDTO(c)).ToList();
        }
    }
}
