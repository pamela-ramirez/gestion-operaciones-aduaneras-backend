using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class FinalizarOperacion : IFinalizarOperacion
    {
        private readonly IRepositorioOperacion _operacionRepositorio;

        public FinalizarOperacion(IRepositorioOperacion operacionRepositorio)
        {
            _operacionRepositorio = operacionRepositorio;
        }
        public OperacionRespuestaDTO Ejecutar(int operacionId)
        {
            var operacion = _operacionRepositorio.FindById(operacionId);
            if (operacion == null)

                throw new OperacionNoEncontradaException();

            operacion.Finalizar();
            _operacionRepositorio.Update(operacion, operacionId);
            return OperacionMapper.ToDTO(operacion);
        }
    }
}
