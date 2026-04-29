using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ModificarUsuario : IModificarUsuario
    {
        private readonly IUsuarioService _usuarioService;

        public ModificarUsuario(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioRespuestaDTO Ejecutar(int id, ModificarUsuarioDTO dto)
        {
            return _usuarioService.ModificarUsuario(id, dto);
        }
    }
}
