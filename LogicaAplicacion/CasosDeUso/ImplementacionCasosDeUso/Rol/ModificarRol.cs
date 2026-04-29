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
    public class ModificarRol : IModificarRol
    {
        private readonly IRolService _rolService;
        public ModificarRol(IRolService rolService) { _rolService = rolService; }

        public RolRespuestaDTO Ejecutar(int id, ModificarRolDTO dto)
            => _rolService.ModificarRol(id, dto);
    }
}
