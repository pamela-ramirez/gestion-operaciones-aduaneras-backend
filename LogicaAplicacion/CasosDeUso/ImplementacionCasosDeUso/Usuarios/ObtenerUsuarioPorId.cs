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
    public class ObtenerUsuarioPorId : IObtenerUsuarioPorId
    {
        private readonly IUsuarioService _usuarioService;

        public ObtenerUsuarioPorId(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public UsuarioRespuestaDTO Ejecutar(int id)
        {
            return _usuarioService.ObtenerUsuarioPorId(id);
        }
    }
}
