using Compartido.DTOs.Despachante;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespachanteController : ControllerBase
    {
        private readonly ICrearDespachante _crearDespachante;
        private readonly IObtenerDespachantePorId _obtenerDespachantePorId;

        public DespachanteController(ICrearDespachante crearDespachante, IObtenerDespachantePorId obtenerDespachantePorId)
        {
            _crearDespachante = crearDespachante;
            _obtenerDespachantePorId = obtenerDespachantePorId;
        }

        // POST /api/despachante - Crear despachante
        [HttpPost]
        public IActionResult Crear([FromBody] CrearDespachanteDTO dto)
        {
            try
            {
                var resultado = _crearDespachante.Ejecutar(dto);
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = resultado.Id },
                    resultado
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // GET /api/despachante/{id} - Obtener despachante por id
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerDespachantePorId.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }

        }
}
