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
        private readonly IAceptarConsentimientoUsuario _aceptarConsentimientoCasoDeUso;
        private readonly ICambiarPasswordUsuario _cambiarPasswordCasoDeUso;

        public AuthController(ILogin loginCasoDeUso, IAceptarConsentimientoUsuario aceptarConsentimientoCasoDeUso, ICambiarPasswordUsuario cambiarPasswordCasoDeUso)
        {
            _loginCasoDeUso = loginCasoDeUso;
            _aceptarConsentimientoCasoDeUso = aceptarConsentimientoCasoDeUso;
            _cambiarPasswordCasoDeUso = cambiarPasswordCasoDeUso;
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

        [Authorize]
        [HttpPost("aceptar-consentimiento")]
        public IActionResult AceptarConsentimiento()
            {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _aceptarConsentimientoCasoDeUso.Ejecutar(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("cambiar-password")]
        public IActionResult CambiarPassword(
        [FromBody] CambiarPasswordDTO dto)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                _cambiarPasswordCasoDeUso.Ejecutar(userId, dto.NuevaPassword);

                return Ok();
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return BadRequest(ModelState);
            }
        }
    }
}
