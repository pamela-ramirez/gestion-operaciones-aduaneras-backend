using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ObtenerUsuarioLogueado : IObtenerUsuarioLogueado
    {
        private readonly IRepositorioUsuario _repo;

        public ObtenerUsuarioLogueado(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public async Task<UsuarioLogueadoDTO> Ejecutar(int id)
        {
            var usuario = _repo.FindById(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado");

            return new UsuarioLogueadoDTO
            {
                Id = usuario.Id,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol.NombreRol,
                Estado = usuario.Estado,
                PrimerLogin = usuario.PrimerLogin
            };
        }


    }
}
