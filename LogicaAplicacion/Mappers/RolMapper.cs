using Compartido.DTOs.Rol;
using LogicaAplicacion.Excepciones.Rol;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.Mappers
{
    public static class RolMapper
    {
        public static Rol ToEntity(RolDTO dto)
        {
            if (dto == null)
                throw new NombreRolNuloException();

            return new Rol(dto.NombreRol);
        }

        public static RolListadoDTO ToDTO(Rol rol)
        {
            if (rol == null)
                throw new NombreRolNuloException();

            return new RolListadoDTO
            {
                Id = rol.Id,
                NombreRol = rol.NombreRol
            };
        }

        public static IEnumerable<RolListadoDTO> ListToDTO(IEnumerable<Rol> roles)
        {
            return roles.Select(r => ToDTO(r));
        }
    }
}