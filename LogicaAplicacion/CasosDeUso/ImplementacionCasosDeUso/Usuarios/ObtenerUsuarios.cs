using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ObtenerUsuarios : IObtenerUsuarios
    {
        private readonly IUsuarioService _usuarioService;

        public ObtenerUsuarios(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public IEnumerable<UsuarioRespuestaDTO> Ejecutar()
        {
            return _usuarioService.ObtenerUsuarios();
        }
    }
}
