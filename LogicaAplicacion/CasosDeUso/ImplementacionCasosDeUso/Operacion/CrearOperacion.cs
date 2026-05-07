using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class CrearOperacion : ICrearOperacion
    {
        private readonly IRepositorioOperacion _operacionRepo;
        private readonly IRepositorioCliente _clienteRepo;
        private readonly IRepositorioTipoOperacion _tipoOperacionRepo;

        public CrearOperacion(IRepositorioOperacion operacionRepo, IRepositorioCliente clienteRepo, IRepositorioTipoOperacion tipoOperacionRepo)
        {
            _operacionRepo = operacionRepo;
            _clienteRepo = clienteRepo;
            _tipoOperacionRepo = tipoOperacionRepo;
        }

        public OperacionRespuestaDTO Ejecutar(CrearOperacionDTO dto)
        {
            var cliente = _clienteRepo.FindById(dto.ClienteId);
            if (cliente == null)
                throw new Exception("El cliente seleccionado no existe.");

            if (_operacionRepo.ExisteNroCarpeta(dto.NroCarpeta))
                throw new Exception("Ya existe una operación con ese número de carpeta.");

            var tipoOperacion = _tipoOperacionRepo.FindById(dto.TipoOperacionId);
            if (tipoOperacion == null)
                throw new Exception("El tipo de operación seleccionado no es válido.");

            var operacion = new LogicaNegocio.Entidades.Operacion(dto.NroCarpeta, tipoOperacion, cliente);

            operacion.Validar();

            _operacionRepo.Add(operacion);

            return OperacionMapper.ToDTO(operacion);
        }

    }
}
