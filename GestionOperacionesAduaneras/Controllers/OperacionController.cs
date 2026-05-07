using Compartido.DTOs.Operacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OperacionController : ControllerBase
    {
        private readonly ICrearOperacion _crearOperacion;
        private readonly IObtenerOperaciones _obtenerOperaciones;
        private readonly IObtenerOperacionesPorCliente _obtenerOperacionesPorCliente;
        private readonly IObtenerOperacionPorId _obtenerOperacionPorId;

        public OperacionController(
            ICrearOperacion crearOperacion,
            IObtenerOperaciones obtenerOperaciones,
            IObtenerOperacionesPorCliente obtenerOperacionesPorCliente,
            IObtenerOperacionPorId obtenerOperacionPorId)
        {
            _crearOperacion = crearOperacion;
            _obtenerOperaciones = obtenerOperaciones;
            _obtenerOperacionesPorCliente = obtenerOperacionesPorCliente;
            _obtenerOperacionPorId = obtenerOperacionPorId;
        }

        // POST /api/operacion
        [HttpPost]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult Crear([FromBody] CrearOperacionDTO dto)
        {
            try
            {
                var resultado = _crearOperacion.Ejecutar(dto);
                // 201 Created + la operación creada
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

        // GET /api/operacion/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerOperacionPorId.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

        // GET /api/operacion
        // Ejemplo: /api/operacion?clienteId=1&tipoOperacionId=2&estado=pendiente&fechaDesde=2024-01-01&fechaHasta=2024-12-31
        [HttpGet]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult ObtenerTodos(
            [FromQuery] int? clienteId,
            [FromQuery] int? tipoOperacionId,
            [FromQuery] string? estado,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta)
        {
            try
            {
                var resultado = _obtenerOperaciones.Ejecutar(
                    clienteId,
                    tipoOperacionId,
                    estado,
                    fechaDesde,
                    fechaHasta);

                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET /api/operacion/cliente/{clienteId}
        [HttpGet("cliente/{clienteId}")]
        public IActionResult ObtenerPorCliente(int clienteId)
        {
            try
            {
                var resultado = _obtenerOperacionesPorCliente.Ejecutar(clienteId);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }


    }
}
