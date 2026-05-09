using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaAplicacion.Mappers;
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
            return usuarios.Select(u => UsuarioMapper.ToListadoDTO(u));
        }
    }
}