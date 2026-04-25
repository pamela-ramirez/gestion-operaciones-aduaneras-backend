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
        UsuarioRespuestaDTO CrearUsuario(CrearUsuarioDTO dto);
        UsuarioRespuestaDTO ObtenerUsuarioPorId(int id);
        UsuarioRespuestaDTO ModificarUsuario(int id, ModificarUsuarioDTO dto);
        void EliminarUsuario(int id);
    }
}
