using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using static Compartido.DTOs.Rol.RolDTO;

namespace GestionOperacionesAduaneras.Servicios
{
    public class RolService : IRolService
    {
        private readonly IRepositorioRol _repositorioRol;

        public RolService(IRepositorioRol repositorioRol)
        {
            _repositorioRol = repositorioRol;
        }

        public RolRespuestaDTO CrearRol(CrearRolDTO dto)
        {
            var rolExistente = _repositorioRol.FindByNombre(dto.NombreRol);
            if (rolExistente != null)
            {
                throw new YaExisteRolConEseNombreException();
            }
            var rol = new Rol(dto.NombreRol);
            _repositorioRol.Add(rol);
            return MapearARespuesta(rol);
        }

        public void EliminarRol(int id)
        {
            var rol = _repositorioRol.FindById(id);
            if (rol == null)
            {
                throw new RolNoEncontradoException();
            }

            _repositorioRol.Delete(id);
        }

        public RolRespuestaDTO ModificarRol(int id, ModificarRolDTO dto)
        {
            var rol = _repositorioRol.FindById(id);
            if (rol == null)
            {
                throw new RolNoEncontradoException();
            }

            rol.NombreRol = dto.NombreRol;
            _repositorioRol.Update(rol, id);
            return MapearARespuesta(rol);
        }

        public RolRespuestaDTO ObtenerRolPorId(int id)
        {
            var rol = _repositorioRol.FindById(id);
            if (rol == null)
            {
                throw new RolNoEncontradoException();
            }

            return MapearARespuesta(rol);
        }

        public IEnumerable<RolRespuestaDTO> ObtenerRoles()
        {
            var roles = _repositorioRol.FindAll();
            return roles.Select(r => MapearARespuesta(r)).ToList();
        }

        // Método privado reutilizable para convertir Rol → RolRespuestaDTO
        private RolRespuestaDTO MapearARespuesta(Rol rol)
        {
            return new RolRespuestaDTO
            {
                Id = rol.Id,
                NombreRol = rol.NombreRol
            };
        }
    }
}
