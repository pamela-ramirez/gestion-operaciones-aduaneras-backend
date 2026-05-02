using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Usuarios
{
    /// <summary>
    /// DTO de RESPUESTA del obtener todos los usuarios.
    public class UsuarioListadoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Devolvemos el nombre del rol, no el ID, para que el frontend lo muestre directo
        public string Rol { get; set; } = string.Empty;

        //agregue estos nuevos atributos porque el frontend los necesita
        public DateTime FechaCreacion { get; set; }

        public bool PrimerLogin { get; set; }

        public string Estado { get; set; } = string.Empty;
    }
}
