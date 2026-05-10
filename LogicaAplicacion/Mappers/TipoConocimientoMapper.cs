using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.TipoConocimiento.TipoConocimientoDTO;

namespace LogicaAplicacion.Mappers
{
    public static class TipoConocimientoMapper
    {
        // Convierte el DTO de creación a la entidad.
        public static TipoConocimiento ToEntity(CrearTipoConocimientoDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Descripcion))
                throw new Exception("La descripción es obligatoria.");

            return new TipoConocimiento(dto.Descripcion);
        }

        // Convierte la entidad al DTO de respuesta.
        public static TipoConocimientoListadoDTO ToDTO(TipoConocimiento tipoConocimiento)
        {
            if (tipoConocimiento == null)
                throw new Exception("El tipo de conocimiento no puede ser nulo.");

            return new TipoConocimientoListadoDTO
            {
                Id = tipoConocimiento.Id,
                Descripcion = tipoConocimiento.Descripcion
            };
        }

        // Convierte una lista de entidades a una lista de DTOs. Para CU de obtener todos.
        public static IEnumerable<TipoConocimientoListadoDTO> ToListaDTO(
            IEnumerable<TipoConocimiento> tipos)
        {
            return tipos.Select(t => ToDTO(t));
        }
    }
}
