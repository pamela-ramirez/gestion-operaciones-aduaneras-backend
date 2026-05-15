using Compartido.DTOs.Documento;

namespace Compartido.DTOs.Operacion
{


    // Datos que manda el frontend al registrar una nueva operación.
    // Solo los campos iniciales: el estado y la fecha los asigna el sistema.
    public class CrearOperacionDTO
    {
        public int ClienteId { get; set; }
        public int TipoOperacionId { get; set; }
        public string NroCarpeta { get; set; } = string.Empty;
    }

    // Datos que manda el frontend al completar la información aduanera.
    // Los tres campos son opcionales (nullables) porque el despachante
    // puede actualizar uno, dos o los tres a la vez.
    public class ActualizarDatosAduanerosDTO
    {
        public string? NroDua { get; set; }
        public int? TipoConocimientoId { get; set; }
        public int? NroConocimiento { get; set; }
    }

    // DTO de RESPUESTA (lo que devuelve el backend al frontend)
    // Información de una operación que se muestra en el listado y detalle.
    public class OperacionListadoDTO
    {
        public int Id { get; set; }
        public string NroCarpeta { get; set; } = string.Empty;
        public DateTime FechaRegistro { get; set; }
        public string Estado { get; set; } = string.Empty;

        public int ClienteId { get; set; }
        public string NombreCliente { get; set; } = string.Empty;
        public string RazonSocialCliente { get; set; } = string.Empty;

        public int TipoOperacionId { get; set; }
        public string TipoOperacion { get; set; } = string.Empty;

        // Datos aduaneros (pueden ser null al inicio)
        public string? NroDua { get; set; }
        public int? TipoConocimientoId { get; set; }
        public string? TipoConocimiento { get; set; }
        public int? NroConocimiento { get; set; }
    }

    // DTO de respuesta al crear o actualizar una operación.
    // Contiene los mismos datos que el listado.
    public class OperacionRespuestaDTO : OperacionListadoDTO { }


    // Listado de documentos asociados a una operación
    public class OperacionListadoDocumentosDTO
    {
        public IEnumerable<DocumentoRespuestaDTO> Documentos { get; set; } = new List<DocumentoRespuestaDTO>();

    }


}

