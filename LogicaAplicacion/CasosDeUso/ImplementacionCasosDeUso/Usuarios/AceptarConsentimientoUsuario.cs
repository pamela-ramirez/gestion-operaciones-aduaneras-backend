using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
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

        public AceptarConsentimientoUsuario (IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public async Task Ejecutar(int userId)
        {
            var usuario = _repo.FindById(userId);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            usuario.Estado = "Activo";

            _repo.Update(usuario, userId);
        }
    }
}
