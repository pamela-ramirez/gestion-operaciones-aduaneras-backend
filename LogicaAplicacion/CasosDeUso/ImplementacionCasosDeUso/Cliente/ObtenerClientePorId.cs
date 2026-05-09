using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Excepciones.Cliente;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class ObtenerClientePorId : IObtenerClientePorId
    {
        private readonly IRepositorioCliente _clienteRepo;
        public ObtenerClientePorId(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ClienteDTO Ejecutar(int id)
        {
            var cliente = _clienteRepo.FindById(id);
            if (cliente == null)
            {
                throw new UsuarioNoEncontradoException();
            }

            return ClienteMapper.ToClienteDTO(cliente);
        }
    }
}
