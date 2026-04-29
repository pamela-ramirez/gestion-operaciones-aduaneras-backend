using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Rol
{
    public class RolDTO
    {
        public class CrearRolDTO
        {
            // Lo que el frontend manda para CREAR un rol
            public string NombreRol { get; set; } = string.Empty;
        }

        // Lo que el frontend manda para MODIFICAR un rol
        public class ModificarRolDTO
        {
            public string NombreRol { get; set; } = string.Empty;
        }

        // Lo que la API DEVUELVE al frontend
        public class RolRespuestaDTO
        {
            public int Id { get; set; }
            public string NombreRol { get; set; } = string.Empty;
        }
    }
}
