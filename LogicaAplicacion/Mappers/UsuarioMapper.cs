using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public static class UsuarioMapper
    {
        public static UsuarioLogueadoDTO ToLogueadoDTO(Usuario usuario)
        {
            return new UsuarioLogueadoDTO
            {
                Id = usuario.Id,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol.NombreRol,
                Estado = usuario.Estado,
                PrimerLogin = usuario.PrimerLogin
            };
        }

        public static UsuarioListadoDTO ToListadoDTO(Usuario usuario)
        {
            return new UsuarioListadoDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol.NombreRol,
                FechaCreacion = usuario.FechaCreacion,
                PrimerLogin = usuario.PrimerLogin,
                Estado = usuario.Estado
            };
        }
    }
}
