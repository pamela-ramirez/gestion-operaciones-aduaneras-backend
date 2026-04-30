using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using Microsoft.AspNetCore.Mvc;
using static Compartido.DTOs.Rol.RolDTO;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly ICrearRol _crearRol;
        private readonly IObtenerRoles _obtenerRoles;
        private readonly IObtenerRolPorId _obtenerRolPorId;
        private readonly IModificarRol _modificarRol;
        private readonly IEliminarRol _eliminarRol;

        public RolController(
            ICrearRol crearRol,
            IObtenerRoles obtenerRoles,
            IObtenerRolPorId obtenerRolPorId,
            IModificarRol modificarRol,
            IEliminarRol eliminarRol)
        {
            _crearRol = crearRol;
            _obtenerRoles = obtenerRoles;
            _obtenerRolPorId = obtenerRolPorId;
            _modificarRol = modificarRol;
            _eliminarRol = eliminarRol;
        }

        // POST /api/rol
        [HttpPost]
        public IActionResult Crear([FromBody] CrearRolDTO dto)
        {
            try
            {
                var resultado = _crearRol.Ejecutar(dto);
                return CreatedAtAction(nameof(ObtenerPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET /api/rol
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerRoles.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET /api/rol/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerRolPorId.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // PUT /api/rol/{id}
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ModificarRolDTO dto)
        {
            try
            {
                var resultado = _modificarRol.Ejecutar(id, dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // DELETE /api/rol/{id}
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                _eliminarRol.Ejecutar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
