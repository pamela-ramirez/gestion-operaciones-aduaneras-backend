using Compartido.DTOs.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaAplicacion.Excepciones.Rol;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class CrearRol : ICrearRol
    {
        private readonly IRepositorioRol _repoRol;
        public CrearRol(IRepositorioRol repoRol)
        {
            _repoRol = repoRol;
        }
        public RolListadoDTO Ejecutar(RolDTO rolDTO)
        {
            var existente = _repoRol.FindByNombre(rolDTO.NombreRol);
            if (existente != null)
                throw new YaExisteRolConEseNombreException();

            var rol = RolMapper.DTORolToRol(rolDTO);
            rol.Validar();

            _repoRol.Add(rol);
            return RolMapper.RolToDTO(rol);
        }
    }
}
