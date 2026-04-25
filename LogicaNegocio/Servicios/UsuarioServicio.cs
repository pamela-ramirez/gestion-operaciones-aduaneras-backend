using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Servicios
{
    public class UsuarioServicio : IUsuarioService
    {
        private readonly IRepositorioUsuario _repositorioUsuario;

        public UsuarioServicio(IRepositorioUsuario repositorioUsuario)
        {
            _repositorioUsuario = repositorioUsuario;
        }
        public UsuarioRespuestaDTO CrearUsuario(CrearUsuarioDTO dto)
        {
            ValidarPassword(dto.Password);

            var emailExistente = _repositorioUsuario.GetByEmail(dto.Email).Result;
            if (emailExistente != null)
                throw new Exception("El correo electrónico ya está registrado.");

            if (dto.RolId <= 0)
                throw new Exception("Debe asignar un rol al usuario.");

            var email = new Email(dto.Email);
            var password = new Password(dto.Password);

            var usuario = new Usuario(dto.Nombre, dto.Apellido, email, password, null)
            {
                RolId = dto.RolId
            };

            _repositorioUsuario.Add(usuario);

            return MapearARespuesta(usuario);

        }

        public void EliminarUsuario(int id)
        {
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            _repositorioUsuario.Delete(id);
        }

        public UsuarioRespuestaDTO ModificarUsuario(int id, ModificarUsuarioDTO dto)
        {
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            if (usuario.Email.Valor != dto.Email)
            {
                var emailEnUso = _repositorioUsuario.GetByEmail(dto.Email).Result;
                if (emailEnUso != null)
                    throw new Exception("El correo electrónico ya está registrado.");
            }

            if (dto.RolId <= 0)
                throw new Exception("Debe asignar un rol al usuario.");

            // Actualizar datos
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Email = new Email(dto.Email);
            usuario.RolId = dto.RolId;

            _repositorioUsuario.Update(usuario, id);

            return MapearARespuesta(usuario);
        }

        public UsuarioRespuestaDTO ObtenerUsuarioPorId(int id)
        {
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            return MapearARespuesta(usuario);
        }

        private void ValidarPassword(string password)
        {
            if (password.Length < 8)
                throw new Exception("La contraseña debe tener al menos 8 caracteres.");

            if (!password.Any(char.IsLetter))
                throw new Exception("La contraseña debe contener al menos una letra.");

            if (!password.Any(char.IsDigit))
                throw new Exception("La contraseña debe contener al menos un número.");
        }

        // Método privado para convertir Usuario a UsuarioRespuestaDTO
        // Lo usamos en varios métodos para no repetir código, si se agregan campos al DTO
        // //solo se cambia en un lugar
        private UsuarioRespuestaDTO MapearARespuesta(Usuario usuario)
        {
            return new UsuarioRespuestaDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol?.NombreRol ?? "Sin rol"
            };
        }
    }
}
