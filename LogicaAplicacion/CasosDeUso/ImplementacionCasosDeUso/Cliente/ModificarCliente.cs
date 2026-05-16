using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Excepciones.Cliente;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class ModificarCliente : IModificarCliente
    {
        private readonly IRepositorioCliente _clienteRepo;
        private readonly IRepositorioUsuario _usuarioRepo;

        public ModificarCliente(IRepositorioCliente clienteRepo, IRepositorioUsuario usuarioRepo)
        {
            _clienteRepo = clienteRepo;
            _usuarioRepo = usuarioRepo;
        }

        public ClienteDTO Ejecutar(int id, ModificarClienteDTO dto)
        {
            var cliente = _clienteRepo.FindById(id);

            if (cliente == null)
                throw new UsuarioNoEncontradoException();

            // Update parcial
            if (!string.IsNullOrWhiteSpace(dto.Nombre))
                cliente.Nombre = dto.Nombre;

            if (!string.IsNullOrWhiteSpace(dto.Apellido))
                cliente.Apellido = dto.Apellido;

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                bool clienteEmail = _usuarioRepo.ExisteEmail(dto.Email);
                if (clienteEmail)
                {
                    throw new UsuarioExistenteConMismoCorreoException();
                }
                else 
                {
                    cliente.Email = new Email(dto.Email);
                }  
            }
            
            if (!string.IsNullOrWhiteSpace(dto.Telefono))
                cliente.Telefono = dto.Telefono;

            if(!string.IsNullOrWhiteSpace(dto.Direccion))
                cliente.Direccion = dto.Direccion;

            if (!string.IsNullOrWhiteSpace(dto.RazonSocial))
                cliente.RazonSocial = dto.RazonSocial;

            if (!string.IsNullOrWhiteSpace(dto.Rut))
            {
                bool clienteRut = _clienteRepo.ExisteRut(dto.Rut, id);
                if (!clienteRut)
                {
                    cliente.Rut = new Rut(dto.Rut);
                }
                else 
                {
                    throw new ClienteExistenteConIgualRutException();
                }
                    
            }

            cliente.Validar();
            _clienteRepo.Update(cliente, id);

            return ClienteMapper.ToClienteDTO(cliente);
        }
    }
}
