using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Excepciones.Cliente;
using LogicaAplicacion.Excepciones.Rol;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class CrearCliente : ICrearCliente
    {
        private readonly IRepositorioCliente _clienteRepo;
        private readonly IRepositorioRol _rolRepo;
        private readonly IRepositorioUsuario _usuarioRepo;

        public CrearCliente(IRepositorioCliente clienteRepo, IRepositorioRol rolRepo, IRepositorioUsuario usuarioRepo)
        {
            _clienteRepo = clienteRepo;
            _rolRepo = rolRepo;
            _usuarioRepo = usuarioRepo;
        }
        public CrearClienteRespuestaDTO Ejecutar(CrearClienteDTO dto)
        {
            var existe = _clienteRepo.ExisteRut(dto.Rut);
            if (existe)
                throw new ClienteExistenteConIgualRutException();

            var existeEmail = _usuarioRepo.ExisteEmail(dto.Email);

            if (existeEmail)
                throw new UsuarioExistenteConMismoCorreoException();

            var rolCliente = _rolRepo.FindById(3);
            if (rolCliente == null)
                throw new RolNoEncontradoException();

            var username = $"{dto.Email.Split('@')[0]}";
            var passwordTemporal = "Despacho100!";

            var cliente = ClienteMapper.ToEntity(dto, rolCliente);

            _clienteRepo.Add(cliente);

            return ClienteMapper.ToDTO(cliente, username, passwordTemporal);

        }
    }
}
