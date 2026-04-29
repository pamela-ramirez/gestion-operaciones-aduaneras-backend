using Compartido.DTOs.Cliente;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.ValueObject;

namespace GestionOperacionesAduaneras.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioRol _repositorioRol;


        public ClienteService(IRepositorioCliente repositorioCliente, IRepositorioRol repositorioRol)
        {
            _repositorioCliente = repositorioCliente;
            _repositorioRol = repositorioRol;
        }

        public ClienteRespuestaDTO CrearCliente(CrearClienteDTO dto)
        {
            var rolCliente = _repositorioRol.FindByNombre("Cliente")
                ?? throw new RolException();

            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = new Email(dto.Email),
                Password = new Password(dto.Password),
                Rut = dto.Rut,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Rol = rolCliente
            };
            _repositorioCliente.Add(cliente);
            return MapearARespuesta(cliente);
        }

        public void EliminarCliente(int id)
        {
            var cliente = _repositorioCliente.FindById(id);

            if (cliente == null)
                throw new ClienteNoEncontradoException();

            _repositorioCliente.Delete(id);

        }

        public ClienteRespuestaDTO ModificarCliente(int id, ModificarClienteDTO dto)
        {
            var cliente = _repositorioCliente.FindById(id);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }
            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;
            cliente.Email = new Email(dto.Email);
            cliente.Rut = dto.Rut;
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;

            _repositorioCliente.Update(cliente, id);
            return MapearARespuesta(cliente);
        }

        public ClienteRespuestaDTO ObtenerClientePorId(int id)
        {
            var cliente = _repositorioCliente.FindById(id);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }
            return MapearARespuesta(cliente);
        }

        public IEnumerable<ClienteRespuestaDTO> ObtenerClientes()
        {
            var clientes = _repositorioCliente.FindAll();
            return clientes.Select(c => MapearARespuesta(c)).ToList();

        }
        private ClienteRespuestaDTO MapearARespuesta(Cliente cliente)
        {
            return new ClienteRespuestaDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email.Valor,
                Rut = cliente.Rut,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion ?? string.Empty
                
            };
        }
    }
}
