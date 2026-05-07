using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Operacion.OperacionDTO;

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
                throw new Exception("Operación no encontrada.");

            return OperacionMapper.ToDTO(operacion);
        }
    }
}
