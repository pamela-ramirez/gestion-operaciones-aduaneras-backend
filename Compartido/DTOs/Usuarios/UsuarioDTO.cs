using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
        public class ModificarUsuarioDTO
        {
            public string Nombre { get; set; } = string.Empty;
            public string Apellido { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;
            public int RolId { get; set; }
        }

        /// <summary>
        /// DTO de RESPUESTA. 
        /// Es lo que la API devuelve al frontend después de cualquier operación.
        /// No se incluye la contraseña, ni siquiera el hash.
        /// En lugar de devolver el RolId devuelve el nombre del rol (ej: "Despachante").
        /// </summary>
        public class UsuarioRespuestaDTO
        {
            public int Id { get; set; }
            public string Nombre { get; set; } = string.Empty;
            public string Apellido { get; set; } = string.Empty;
            public string Email { get; set; } = string.Empty;

            // Devolvemos el nombre del rol, no el ID, para que el frontend lo muestre directo
            public string Rol { get; set; } = string.Empty;
        }
    }
