using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioController : ControllerBase
    {
        private readonly IObtenerUsuarios _obtenerUsuarios;
        private readonly IObtenerUsuarioPorId _obtenerUsuarioPorId;
        private readonly IEliminarUsuario _eliminarUsuario;
        private readonly IObtenerUsuarioLogueado _obtenerUsuarioLogueado;

        public UsuarioController(
            IObtenerUsuarios obtenerUsuarios,
            IObtenerUsuarioPorId obtenerUsuarioPorId,
            IEliminarUsuario eliminarUsuario,
            IObtenerUsuarioLogueado obtenerUsuarioLogueado
        )
        {
            _obtenerUsuarios = obtenerUsuarios;
            _obtenerUsuarioPorId = obtenerUsuarioPorId;
            _eliminarUsuario = eliminarUsuario;
            _obtenerUsuarioLogueado = obtenerUsuarioLogueado;
        }


        // GET /api/usuarios/{id} - Obtener usuario por ID
        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerUsuarioPorId.Ejecutar(id);
                // 200 OK con el usuario encontrado
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // 404 Not Found si no se encuentra el usuario
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // GET /api/usuarios - Obtener todos los usuarios
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerUsuarios.Ejecutar();
                // 200 OK con la lista de usuarios
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // 400 Bad Request con el msj de error
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE /api/usuarios/{id} - Eliminar usuario
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                _eliminarUsuario.Ejecutar(id);
                // 204 No Content si se eliminó correctamente, no devuelve contenido
                return NoContent();
            }
            catch (Exception ex)
            {
                // 404 Not Found si no se encuentra el usuario
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // GET /api/usuarios/logueado - Obtener usuario logueado
        [HttpGet("logueado")]
        public async Task<IActionResult> ObtenerUsuarioLogueado()
        {
            try
            {
                var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (userIdClaim == null)
                    return Unauthorized();

                int userId = int.Parse(userIdClaim);

                var resultado = await _obtenerUsuarioLogueado.Ejecutar(userId);
                // 200 OK con el usuario logueado
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // 401 Unauthorized si no hay un usuario logueado
                return Unauthorized(new { mensaje = ex.Message });
            }
        }
    }
}
