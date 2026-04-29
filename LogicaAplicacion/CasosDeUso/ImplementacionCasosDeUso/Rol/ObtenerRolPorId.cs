using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Rol.RolDTO;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class ObtenerRolPorId : IObtenerRolPorId
    {
        private readonly IRolService _rolService;
        public ObtenerRolPorId(IRolService rolService) { _rolService = rolService; }

        public RolRespuestaDTO Ejecutar(int id) => _rolService.ObtenerRolPorId(id);
    }
}
