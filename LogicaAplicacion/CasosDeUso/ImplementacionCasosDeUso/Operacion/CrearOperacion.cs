using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
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
                throw new ClienteSeleccionadoNoExisteException();

            if (_operacionRepo.ExisteNroCarpeta(dto.NroCarpeta))
                throw new OperacionExistenteConMismoNroCarpetaException();

            var tipoOperacion = _tipoOperacionRepo.FindById(dto.TipoOperacionId);
            if (tipoOperacion == null)
                throw new TipoDeOperacionNoEncontradoException();

            var operacion = OperacionMapper.ToEntity(dto, tipoOperacion, cliente);
            operacion.Validar();

            _operacionRepo.Add(operacion);

            return OperacionMapper.ToDTO(operacion);
        }

    }
}
