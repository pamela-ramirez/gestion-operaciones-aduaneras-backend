using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
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

        public async Task Ejecutar(int userId, string nuevaPassword)
        {
            var usuario = _repo.FindById(userId);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            // validación (podés reutilizar la que ya tenés)
            if (nuevaPassword.Length < 8)
                throw new Exception("Debe tener al menos 8 caracteres");

            usuario.Password = new Password(nuevaPassword);
            usuario.PrimerLogin = false;

            _repo.Update(usuario, userId);
        }
    }
}

