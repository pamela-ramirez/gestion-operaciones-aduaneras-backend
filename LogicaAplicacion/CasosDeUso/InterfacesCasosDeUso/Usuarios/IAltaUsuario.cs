using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IAltaUsuario
    {
        Task<UsuarioDTO> Ejecutar(AltaUsuarioDTO dto);
    }
}
