using Compartido.DTOs.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly ICrearUsuario _crearUsuario;
        private readonly IObtenerUsuarios _obtenerUsuarios;
        private readonly IObtenerUsuarioPorId _obtenerUsuarioPorId;
        private readonly IModificarUsuario _modificarUsuario;
        private readonly IEliminarUsuario _eliminarUsuario;

        public UsuarioController(
            ICrearUsuario crearUsuario,
            IObtenerUsuarios obtenerUsuarios,
            IObtenerUsuarioPorId obtenerUsuarioPorId,
            IModificarUsuario modificarUsuario,
            IEliminarUsuario eliminarUsuario
        )
        {
            _crearUsuario = crearUsuario;
            _obtenerUsuarios = obtenerUsuarios;
            _obtenerUsuarioPorId = obtenerUsuarioPorId;
            _modificarUsuario = modificarUsuario;
            _eliminarUsuario = eliminarUsuario;
        }


        // POST  /api/usuarios - Crear usuarios
        [HttpPost]
        public IActionResult Crear([FromBody] CrearUsuarioDTO dto)
        {
            try
            {
                // 201 Created y la ubicacion del nuevo usuario
                var resultado = _crearUsuario.Ejecutar(dto);
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

        // PUT /api/usuarios/{id} - Modificar usuario
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ModificarUsuarioDTO dto)
        {
            try
            {
                var resultado = _modificarUsuario.Ejecutar(id, dto);
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
    }
}
