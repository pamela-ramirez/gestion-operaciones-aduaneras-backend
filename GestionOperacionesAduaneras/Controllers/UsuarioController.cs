using Compartido.DTOs.Usuarios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        // POST  /api/usuarios - Crear usuarios
        [HttpPost]
        public IActionResult Crear([FromBody] CrearUsuarioDTO dto)
        {
            try
            {
                // 201 Created y la ubicacion del nuevo usuario
                var resultado = _usuarioService.CrearUsuario(dto);
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = resultado.Id },
                    resultado
                );
            }
            catch (Exception ex)
            {
                // 400 Bad Request con el msj de error
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET /api/usuarios/{id} - Obtener usuario por ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _usuarioService.ObtenerUsuarioPorId(id);
                // 200 OK con el usuario encontrado
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                // 404 Not Found si no se encuentra el usuario
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // PUT /api/usuarios/{id} - Modificar usuario
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ModificarUsuarioDTO dto)
        {
            try
            {
                var resultado = _usuarioService.ModificarUsuario(id, dto);
                // 200 OK con el usuario modificado
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
        public IActionResult Eliminar(int id)
        {
            try
            {
                _usuarioService.EliminarUsuario(id);
                // 204 No Content si se eliminó correctamente, no devuelve contenido
                return NoContent();
            }
            catch (Exception ex)
            {
                // 404 Not Found si no se encuentra el usuario
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
