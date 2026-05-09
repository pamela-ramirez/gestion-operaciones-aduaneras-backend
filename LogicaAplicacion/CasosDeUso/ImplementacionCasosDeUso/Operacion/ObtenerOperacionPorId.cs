using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ObtenerOperacionPorId : IObtenerOperacionPorId
    {
        private readonly IRepositorioOperacion _operacionRepo;

        public ObtenerOperacionPorId(IRepositorioOperacion operacionRepo)
        {
            _operacionRepo = operacionRepo;
        }

        public OperacionRespuestaDTO Ejecutar(int operacionId)
        {
            var operacion = _operacionRepo.FindById(operacionId);
            if (operacion == null)
                throw new OperacionNoEncontradaException();

            return OperacionMapper.ToDTO(operacion);
        }
    }
}
