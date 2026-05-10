using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.TipoConocimiento
{
    public class TipoConocimientoDTO
    {
        // DTO para CREAR un tipo de conocimiento.
        public class CrearTipoConocimientoDTO
        {
            public string Descripcion { get; set; } = string.Empty;
        }

        // DTO de RESPUESTA. Se usa tanto al crear como al listar.
        // Incluye el ID para que el frontend pueda referenciarlo.
        public class TipoConocimientoListadoDTO
        {
            public int Id { get; set; }
            public string Descripcion { get; set; } = string.Empty;
        }
    }
}
