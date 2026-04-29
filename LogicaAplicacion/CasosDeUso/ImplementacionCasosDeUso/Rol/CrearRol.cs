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
    public class CrearRol : ICrearRol
    {
        private readonly IRolService _rolService;
        public CrearRol(IRolService rolService) { 

            _rolService = rolService; 
        }

        public RolRespuestaDTO Ejecutar(CrearRolDTO dto) => _rolService.CrearRol(dto);
    }
}
