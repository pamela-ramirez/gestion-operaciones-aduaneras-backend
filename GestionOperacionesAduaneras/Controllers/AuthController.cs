using Compartido.DTOs.Auth;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.Excepciones.Usuarios.Login;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILogin _loginCasoDeUso;

        public AuthController(ILogin loginCasoDeUso)
        {
            _loginCasoDeUso = loginCasoDeUso;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            try
            {
                var resultado = await _loginCasoDeUso.Ejecutar(dto);
                return Ok(resultado); // 200 + token
            }
            catch (UsuarioNoEncontradoException ex)
            {
                return Unauthorized(ex.Message); // 401
            }
            catch (CredencialesInvalidasException ex)
            {
                return Unauthorized(ex.Message); // 401
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message); 
            }
        }

        [Authorize]
        [HttpGet("privado")]
        public IActionResult Privado()
        {
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var rol = User.FindFirst(ClaimTypes.Role)?.Value;

            return Ok(new
            {
                mensaje = "Solo con token",
                email,
                rol
            });
        }
    }
}
