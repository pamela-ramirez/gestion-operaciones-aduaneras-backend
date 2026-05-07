using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ObtenerOperacionesPorCliente : IObtenerOperacionesPorCliente
    {
        private readonly IRepositorioOperacion _operacionRepo;
        private readonly IRepositorioCliente _clienteRepo;

        public ObtenerOperacionesPorCliente(
            IRepositorioOperacion operacionRepo,
            IRepositorioCliente clienteRepo)
        {
            _operacionRepo = operacionRepo;
            _clienteRepo = clienteRepo;
        }

        public IEnumerable<OperacionListadoDTO> Ejecutar(int clienteId)
        {
            // Verificamos que el cliente exista antes de buscar sus operaciones
            var cliente = _clienteRepo.FindById(clienteId);
            if (cliente == null)
                throw new Exception("Cliente no encontrado.");

            return _operacionRepo
                .FindByClienteId(clienteId)
                .Select(OperacionMapper.ToListadoDTO)
                .ToList();
        }
    }
}
