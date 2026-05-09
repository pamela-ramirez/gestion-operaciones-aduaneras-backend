using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Operacion
{
    public class ObtenerOperaciones : IObtenerOperaciones
    {
        private readonly IRepositorioOperacion _operacionRepo;

        public ObtenerOperaciones(IRepositorioOperacion operacionRepo)
        {
            _operacionRepo = operacionRepo;
        }

        public IEnumerable<OperacionListadoDTO> Ejecutar()
        {
            var operaciones = _operacionRepo.FindAll();
            return operaciones
                .Select(OperacionMapper.ToListadoDTO)
                .ToList();
        }
    }
}
