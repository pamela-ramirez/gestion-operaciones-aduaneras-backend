using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Excepciones.Usuario;
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

        public ModificarClienteDTO Ejecutar(int id, ModificarClienteDTO dto)
        {
            var cliente = _clienteRepo.FindById(id);

            if (cliente == null)
                throw new UsuarioNoEncontradoException();

            // Update parcial
            if (!string.IsNullOrWhiteSpace(dto.Nombre))
                cliente.Nombre = dto.Nombre;

            if (!string.IsNullOrWhiteSpace(dto.Apellido))
                cliente.Apellido = dto.Apellido;

            if (!string.IsNullOrWhiteSpace(dto.Telefono))
                cliente.Telefono = dto.Telefono;

            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var clienteConEmail = _usuarioRepo.GetByEmail(dto.Email);
                if (clienteConEmail != null && clienteConEmail.Id != id)
                    throw new UsuarioExistenteConMismoCorreoException();

                cliente.Email = new Email(dto.Email);
            }

            cliente.Validar();
            _clienteRepo.Update(cliente, id);

            return dto;
        }
    }
}
