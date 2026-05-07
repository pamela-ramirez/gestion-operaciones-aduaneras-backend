using Compartido.DTOs.TipoOperacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoOperacionController : ControllerBase
    {
        private readonly ICrearTipoOperacion _crearTipoOperacion;
        private readonly IObtenerTiposOperacion _obtenerTiposOperacion;
        private readonly IObtenerTipoOperacionPorId _obtenerTipoOperacionPorId;

        public TipoOperacionController(
            ICrearTipoOperacion crearTipoOperacion,
            IObtenerTiposOperacion obtenerTiposOperacion,
            IObtenerTipoOperacionPorId obtenerTipoOperacionPorId)
        {
            _crearTipoOperacion = crearTipoOperacion;
            _obtenerTiposOperacion = obtenerTiposOperacion;
            _obtenerTipoOperacionPorId = obtenerTipoOperacionPorId;
        }

        // POST /api/tipooperacion
        // Solo admin puede crear nuevos tipos de operación
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Crear([FromBody] CrearTipoOperacionDTO dto)
        {
            try
            {
                var resultado = _crearTipoOperacion.Ejecutar(dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET /api/tipooperacion
        [HttpGet]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerTiposOperacion.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET /api/tipooperacion/{id}
        [HttpGet("{id}")]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerTipoOperacionPorId.Ejecutar(id);
                if (resultado == null)
                    return NotFound(new { mensaje = "Tipo de operación no encontrado" });
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }
    }
}
