using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class CambiarPasswordUsuario : ICambiarPasswordUsuario
    {
        private readonly IRepositorioUsuario _repo;

        public CambiarPasswordUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public void Ejecutar(int userId, string nuevaPassword)
        {
            var usuario = _repo.FindById(userId);
            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            usuario.CambiarPassword(nuevaPassword); // La lógica está en la entidad

            _repo.Update(usuario, userId);
        }
    }
}

