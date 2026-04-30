using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class AltaUsuario : IAltaUsuario
    {
        private readonly IRepositorioUsuario _repoUsuario;

        public AltaUsuario(IRepositorioUsuario repoUsuario)
        {
            _repoUsuario = repoUsuario;
        }

        public Task<UsuarioDTO> Ejecutar(AltaUsuarioDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
