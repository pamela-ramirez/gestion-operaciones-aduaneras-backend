using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class EliminarUsuario : IEliminarUsuario
    {
        private readonly IUsuarioService _usuarioService;

        public EliminarUsuario(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        public void Ejecutar(int id)
        {
            _usuarioService.EliminarUsuario(id);
        }
    }
}
