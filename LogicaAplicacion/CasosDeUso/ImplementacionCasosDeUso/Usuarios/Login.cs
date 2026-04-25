using BCrypt.Net;
using Compartido.DTOs.Auth;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.Excepciones.Usuarios.Login;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios
{
    public class Login : ILogin
    {
        private readonly IRepositorioUsuario _repoUsuario;
        private readonly IJwtService _jwtService;
        

        public Login(IRepositorioUsuario repoUsuario, IJwtService jwtService)
        {
            _repoUsuario = repoUsuario;
            _jwtService = jwtService;
        }
        public async Task<LoginResponseDTO> Ejecutar(LoginDTO dto)
        {
            // Normalizar el email
            dto.Email = dto.Email.Trim().ToLower();
            // Paso 1: buscar el usuario por email
            var usuario = await _repoUsuario.GetByEmail(dto.Email);

            // Paso 2: si no existe, lanzar excepción
            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            // Paso 3: verificar que la contraseña coincida con el hash guardado
            //produccion:
            //bool passwordCorrecta = BCrypt.Net.BCrypt.Verify(dto.Password, usuario.Password.Valor);
            
            //empieza desarrollo/testing
            bool passwordCorrecta;

            if (usuario.Password.Valor.StartsWith("$2"))
            {
                passwordCorrecta = BCrypt.Net.BCrypt.Verify(
                    dto.Password,
                    usuario.Password.Valor
                );
            }
            else
            {
                passwordCorrecta = dto.Password == usuario.Password.Valor;
            }
            //termina desarrollo/testing

            if (!passwordCorrecta)
                throw new CredencialesInvalidasException();

            // Paso 4: generar el token JWT
            var token = _jwtService.GenerarToken(usuario);

            // Paso 5: devolver la respuesta
            return new LoginResponseDTO
            {
                Token = token,
                Rol = usuario.Rol.NombreRol
            };
        }

    }

}

