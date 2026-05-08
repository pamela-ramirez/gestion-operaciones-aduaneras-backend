using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
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
            return clientes.Select(c => new ClienteDTO
            {
                Id = c.Id,
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Email = c.Email.Valor,
                RazonSocial = c.RazonSocial,
                Rut = c.Rut.Valor,
                Telefono = c.Telefono,
                Direccion = c.Direccion,
                Estado = c.Estado
            }).ToList();
        }
    }
}
