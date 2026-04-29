using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class EliminarRol : IEliminarRol
    {
        private readonly IRolService _rolService;
        public EliminarRol(IRolService rolService) { 
            _rolService = rolService; 
        }

        public void Ejecutar(int id) => _rolService.EliminarRol(id);
    }
}
