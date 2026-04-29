using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Rol.RolDTO;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IRolService
    {
        IEnumerable<RolRespuestaDTO> ObtenerRoles();
        RolRespuestaDTO ObtenerRolPorId(int id);
        RolRespuestaDTO CrearRol(CrearRolDTO dto);
        RolRespuestaDTO ModificarRol(int id, ModificarRolDTO dto);
        void EliminarRol(int id);
    }
}
