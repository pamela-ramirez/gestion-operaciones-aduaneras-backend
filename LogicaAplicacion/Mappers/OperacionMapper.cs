using Compartido.DTOs.Operacion;
using LogicaNegocio.Entidades;

namespace LogicaAplicacion.Mappers
{
    public static class OperacionMapper
    {
        // Convierte el DTO de creación a Operacion
        public static Operacion ToEntity(CrearOperacionDTO dto, TipoOperacion tipoOperacion, Cliente cliente)
        {
            return new Operacion(dto.NroCarpeta, tipoOperacion, cliente);
        }

        // Convierte una entidad Operacion al DTO de respuesta
        public static OperacionRespuestaDTO ToDTO(Operacion operacion)
        {
            return new OperacionRespuestaDTO
            {
                Id = operacion.Id,
                NroCarpeta = operacion.NroCarpeta,
                FechaRegistro = operacion.FechaRegistro,

                // Convertimos el enum a texto legible para el frontend
                // Por ejemplo: EstadoOperacion.EnProceso → "En proceso"
                Estado = operacion.Estado switch
                {
                    EstadoOperacion.Iniciado => "Iniciado",
                    EstadoOperacion.DocumentacionPendiente => "Documentación pendiente",
                    EstadoOperacion.EnProceso => "En proceso",
                    EstadoOperacion.Finalizado => "Finalizado",
                    _ => operacion.Estado.ToString()
                },

                ClienteId = operacion.ClienteId,
                NombreCliente = $"{operacion.Cliente?.Nombre} {operacion.Cliente?.Apellido}".Trim(),
                RazonSocialCliente = operacion.Cliente?.RazonSocial ?? string.Empty,

                TipoOperacionId = operacion.TipoOperacionId,
                TipoOperacion = operacion.TipoOperacion?.Descripcion ?? string.Empty,

                NroDua = operacion.NroDua,
                TipoConocimientoId = operacion.TipoConocimientoId,
                TipoConocimiento = operacion.TipoConocimiento?.Descripcion,
                NroConocimiento = operacion.NroConocimiento
            };
        }

        // Convierte al DTO de listado (mismo contenido, nombre diferente para claridad).
        public static OperacionListadoDTO ToListadoDTO(Operacion operacion)
        {
            var dto = ToDTO(operacion);
            return new OperacionListadoDTO
            {
                Id = dto.Id,
                NroCarpeta = dto.NroCarpeta,
                FechaRegistro = dto.FechaRegistro,
                Estado = dto.Estado,
                ClienteId = dto.ClienteId,
                NombreCliente = dto.NombreCliente,
                RazonSocialCliente = dto.RazonSocialCliente,
                TipoOperacionId = dto.TipoOperacionId,
                TipoOperacion = dto.TipoOperacion,
                NroDua = dto.NroDua,
                TipoConocimientoId = dto.TipoConocimientoId,
                TipoConocimiento = dto.TipoConocimiento,
                NroConocimiento = dto.NroConocimiento
            };
        }
    }
}