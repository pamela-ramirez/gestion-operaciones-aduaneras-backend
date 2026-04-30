using Compartido.DTOs.Rol;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Roles;

namespace LogicaAplicacion.Mappers
{
    public static class RolMapper
    {
        public static Rol DTORolToRol(RolDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.NombreRol))
                throw new RolDatosIncorrectosException();

            return new Rol(dto.NombreRol);
        }

        public static RolListadoDTO RolToDTO(Rol rol)
        {
            if (rol == null)
                throw new RolDatosIncorrectosException();

            return new RolListadoDTO
            {
                Id = rol.Id,
                NombreRol = rol.NombreRol
            };
        }

        public static IEnumerable<RolListadoDTO> ListToDTO(IEnumerable<Rol> roles)
        {
            return roles.Select(r => new RolListadoDTO
            {
                Id = r.Id,
                NombreRol = r.NombreRol
            });
        }
    }
}