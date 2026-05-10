using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Excepciones.TipoConocimiento;
using LogicaAplicacion.Mappers;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ActualizarOperacion : IActualizarOperacion
    {
        private readonly IRepositorioOperacion _operacionRepo;
        private readonly IRepositorioTipoConocimiento _tipoConocimientoRepo;

        public ActualizarOperacion(IRepositorioOperacion operacionRepo, IRepositorioTipoConocimiento tipoConocimientoRepo)
        {
            _operacionRepo = operacionRepo;
            _tipoConocimientoRepo = tipoConocimientoRepo;
        }
        public OperacionRespuestaDTO Ejecutar(int operacionId, ActualizarDatosAduanerosDTO dto)
        {
            var operacion = _operacionRepo.FindById(operacionId);
            if (operacion == null)
                throw new OperacionNoEncontradaException();

            TipoConocimiento? tipoConocimiento = null;
            if (dto.TipoConocimientoId.HasValue)
            {
                tipoConocimiento = _tipoConocimientoRepo.FindById(dto.TipoConocimientoId.Value);
                if (tipoConocimiento == null)
                    throw new TipoConocimientoNoEncontradoException();
            }

            // Delegar la lógica a la entidad (valida y actualiza su estado)
            operacion.ActualizarDatosAduaneros(dto.NroDua, tipoConocimiento, dto.NroConocimiento);

            _operacionRepo.Update(operacion, operacionId);

            return OperacionMapper.ToDTO(operacion);
        }
    }
}
