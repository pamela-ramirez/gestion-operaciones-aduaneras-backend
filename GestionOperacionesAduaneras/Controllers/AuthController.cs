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

        public AuthController(ILogin loginCasoDeUso, IAceptarConsentimientoUsuario aceptarConsentimientoCasoDeUso)
        {
            _loginCasoDeUso = loginCasoDeUso;
            _aceptarConsentimientoCasoDeUso = aceptarConsentimientoCasoDeUso;
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
        [HttpPost("consentimiento")]
        public async Task<IActionResult> AceptarConsentimiento(
        [FromServices] IAceptarConsentimientoUsuario casoUso)
            {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await casoUso.Ejecutar(userId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("cambiar-password")]
        public async Task<IActionResult> CambiarPassword(
        [FromBody] CambiarPasswordDTO dto,
        [FromServices] ICambiarPasswordUsuario casoUso)
        {
            try
            {
                var userId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).Value);

                await casoUso.Ejecutar(userId, dto.NuevaPassword);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
