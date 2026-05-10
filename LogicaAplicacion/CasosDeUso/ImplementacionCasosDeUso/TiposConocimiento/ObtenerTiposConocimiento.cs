using Compartido.DTOs.TipoConocimiento;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TiposConocimiento;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.TipoConocimiento.TipoConocimientoDTO;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.TiposConocimiento
{
    public class ObtenerTiposConocimiento : IObtenerTiposConocimiento
    {
        private readonly IRepositorioTipoConocimiento _repositorioTipoConocimiento;

        public ObtenerTiposConocimiento(IRepositorioTipoConocimiento repositorioTipoConocimiento)
        {
            _repositorioTipoConocimiento = repositorioTipoConocimiento;
        }
        public IEnumerable<TipoConocimientoListadoDTO> Ejecutar()
        {
            var tiposConocimiento = _repositorioTipoConocimiento.FindAll();
            return TipoConocimientoMapper.ToListaDTO(tiposConocimiento); 
        }
    }
}
