using Compartido.DTOs.Cliente;
using LogicaAccesoDatos.Repositorios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.Excepciones.Rut;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.ValueObject;

namespace GestionOperacionesAduaneras.Servicios
{
    public class ClienteService : IClienteService
    {
        private readonly IRepositorioCliente _repositorioCliente;
        private readonly IRepositorioRol _repositorioRol;
        private readonly IRepositorioUsuario _repositorioUsuario;


        public ClienteService(IRepositorioCliente repositorioCliente, IRepositorioRol repositorioRol, IRepositorioUsuario repositorioUsuario)
        {
            _repositorioCliente = repositorioCliente;
            _repositorioRol = repositorioRol;
            _repositorioUsuario = repositorioUsuario;
        }

        public ClienteRespuestaDTO CrearCliente(CrearClienteDTO dto)
        {
            Rut rut;
            try
            {
                rut = new Rut(dto.Rut);
            }
            catch (RutVacioException ex)
            {
                throw new ClassException(ex.Message);
            }
            catch (RutSoloNumerosException ex)
            {
                throw new ClassException(ex.Message);
            }
            catch (RutSoloConDoceDigitosException ex)
            {
                throw new ClassException(ex.Message);
            }
            catch (RutNumerosIgualesException ex)
            {
                throw new ClassException(ex.Message);
            }
            catch (RutNoValidoException ex)
            {
                throw new ClassException(ex.Message);
            }

            if (_repositorioCliente.ExisteRut(rut.Valor))
                throw new ClienteExistenteConIgualRutException();

            var emailExistente = _repositorioUsuario.GetByEmail(dto.Email).Result;
            if (emailExistente != null)
                throw new UsuarioExistenteConMismoCorreoException();


            var rolCliente = _repositorioRol.FindByNombre("Cliente")
                ?? throw new RolNoEncontradoException();

            var cliente = new Cliente
            {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = new Email(dto.Email),
                Password = new Password(dto.Password),
                Rut = rut,
                Telefono = dto.Telefono,
                Direccion = dto.Direccion,
                Rol = rolCliente
            };

            cliente.ValidarCliente();
            
            _repositorioCliente.Add(cliente);
            return MapearARespuesta(cliente);
        }

        public void EliminarCliente(int id)
        {
            var cliente = _repositorioCliente.FindById(id);

            if (cliente == null)
                throw new ClienteNoEncontradoException();

            if (_repositorioCliente.TieneOperacionesActivas(id))
                throw new ClienteConOperacionesActivasException();

            _repositorioCliente.Delete(id);

        }

        public ClienteRespuestaDTO ModificarCliente(int id, ModificarClienteDTO dto)
        {
            var cliente = _repositorioCliente.FindById(id);
            if (cliente == null)
            {
                throw new ClienteNoEncontradoException();
            }

            // Verificar email duplicado solo si cambió
            if (cliente.Email.Valor != dto.Email.Trim().ToLower())
            {
                var emailExistente = _repositorioUsuario.GetByEmail(dto.Email).Result;
                if (emailExistente != null)
                    throw new UsuarioExistenteConMismoCorreoException();
            }

            // Verificar RUT duplicado solo si cambió, excluyendo al cliente actual
            if (cliente.Rut.Valor != dto.Rut && _repositorioCliente.ExisteRut(dto.Rut, id))
                throw new ClienteExistenteConIgualRutException();

            cliente.Nombre = dto.Nombre;
            cliente.Apellido = dto.Apellido;
            cliente.Email = new Email(dto.Email);
            cliente.Rut = new Rut(dto.Rut);
            cliente.Telefono = dto.Telefono;
            cliente.Direccion = dto.Direccion;
            
            cliente.ValidarCliente();

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
                Rut = cliente.Rut.Valor,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion ?? string.Empty
                
            };
        }
    }
}
