using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesServicios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ObtenerUsuarioPorId : IObtenerUsuarioPorId
    {
        private readonly IUsuarioService _usuarioService;

        public ObtenerUsuarioPorId(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public UsuarioListadoDTO Ejecutar(int id)
        {
            return _usuarioService.ObtenerUsuarioPorId(id);
        }
    }
}
