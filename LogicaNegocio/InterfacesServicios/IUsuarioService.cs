using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IUsuarioService
    {
        UsuarioListadoDTO ObtenerUsuarioPorId(int id);
        UsuarioListadoDTO ModificarUsuario(int id, ModificarUsuarioDTO dto);
        void EliminarUsuario(int id);
        IEnumerable<UsuarioListadoDTO> ObtenerUsuarios();
    }
}
