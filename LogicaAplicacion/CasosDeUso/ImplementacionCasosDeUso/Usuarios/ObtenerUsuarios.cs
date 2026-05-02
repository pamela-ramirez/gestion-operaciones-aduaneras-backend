using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class ObtenerUsuarios : IObtenerUsuarios
    {
        private readonly IRepositorioUsuario _repo;

        public ObtenerUsuarios(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public IEnumerable<UsuarioListadoDTO> Ejecutar()
        {
            var usuarios = _repo.FindAll();

            return usuarios.Select(u => new UsuarioListadoDTO
            {
                Id = u.Id,
                Nombre = u.Nombre,
                Apellido = u.Apellido,
                Email = u.Email.Valor,
                Rol = u.Rol.NombreRol,
                FechaCreacion = u.FechaCreacion,
                PrimerLogin = u.PrimerLogin,
                Estado = u.Estado
            });
        }
    }
}