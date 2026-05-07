using Compartido.DTOs.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class CrearRol : ICrearRol
    {
        public IRepositorioRol RepoRol { get; set; }
        public CrearRol(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }
        public RolListadoDTO Ejecutar(RolDTO rolDTO)
        {
            var rol = RolMapper.DTORolToRol(rolDTO);

            RepoRol.Add(rol);

            return RolMapper.RolToDTO(rol);
        }

    }
}
