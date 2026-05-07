using Compartido.DTOs.TipoOperacion;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.Mappers
{
    public static class TipoOperacionMapper
    {
        // Convierte el DTO de creación a la entidad.
        public static TipoOperacion ToEntity(CrearTipoOperacionDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Descripcion))
                throw new Exception("La descripción del tipo de operación es obligatoria.");

            return new TipoOperacion(dto.Descripcion);
        }

        // Convierte la entidad al DTO de respuesta.
        public static TipoOperacionListadoDTO ToDTO(TipoOperacion tipoOperacion)
        {
            if (tipoOperacion == null)
                throw new Exception("El tipo de operación no puede ser nulo.");

            return new TipoOperacionListadoDTO
            {
                Id = tipoOperacion.Id,
                Descripcion = tipoOperacion.Descripcion
            };
        }

        // Convierte una lista de entidades a una lista de DTOs. Para CU de obtener todos
        public static IEnumerable<TipoOperacionListadoDTO> ToListaDTO(
            IEnumerable<TipoOperacion> tipos)
        {
            return tipos.Select(t => ToDTO(t));
        }
    }
}
