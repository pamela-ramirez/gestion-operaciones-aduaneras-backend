using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class AceptarConsentimientoUsuario : IAceptarConsentimientoUsuario
    {
        private readonly IRepositorioUsuario _repo;

        public AceptarConsentimientoUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int userId)
        {
            var usuario = _repo.FindById(userId);

            if (usuario == null)
                throw new UsuarioNoEncontradoException();
            _repo.AceptarConsentimeinto(userId);
        }
    }
}
