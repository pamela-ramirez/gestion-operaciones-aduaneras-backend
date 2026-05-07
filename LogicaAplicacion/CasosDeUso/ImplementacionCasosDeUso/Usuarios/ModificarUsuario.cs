using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ModificarUsuario : IModificarUsuario
    {
        private readonly IUsuarioService _usuarioService;

        public ModificarUsuario(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public UsuarioListadoDTO Ejecutar(int id, ModificarUsuarioDTO dto)
        {
            return _usuarioService.ModificarUsuario(id, dto);
        }
    }
}
