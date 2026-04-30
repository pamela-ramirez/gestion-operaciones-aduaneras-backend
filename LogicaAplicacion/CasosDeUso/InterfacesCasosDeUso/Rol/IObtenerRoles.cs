using Compartido.DTOs.Rol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Rol.RolDTO;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol
{
    public interface IObtenerRoles
    {
        //IEnumerable<RolRespuestaDTO> Ejecutar();
        IEnumerable<RolListadoDTO> Ejecutar();
    }
}
