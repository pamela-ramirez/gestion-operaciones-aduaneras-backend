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
        private readonly IObtenerOperacionesConFiltros _obtenerOperacionesConFiltros;
        private readonly IObtenerOperacionesPorCliente _obtenerOperacionesPorCliente;
        private readonly IObtenerOperacionPorId _obtenerOperacionPorId;
        private readonly IActualizarOperacion _actualizarOperacion;
        private readonly IFinalizarOperacion _finalizarOperacion;
        private readonly IObtenerDocumentosPorOperacion _obtenerDocumentosPorOperacion;

        public OperacionController(
            ICrearOperacion crearOperacion,
            IObtenerOperaciones obtenerOperaciones,
            IObtenerOperacionesConFiltros obtenerOperacionesConFiltros,
            IObtenerOperacionesPorCliente obtenerOperacionesPorCliente,
            IObtenerOperacionPorId obtenerOperacionPorId,
            IActualizarOperacion actualizarOperacion,
            IFinalizarOperacion finalizarOperacion,
            IObtenerDocumentosPorOperacion obtenerDocumentosPorOperacion)
        {
            _crearOperacion = crearOperacion;
            _obtenerOperaciones = obtenerOperaciones;
            _obtenerOperacionesConFiltros = obtenerOperacionesConFiltros;
            _obtenerOperacionesPorCliente = obtenerOperacionesPorCliente;
            _obtenerOperacionPorId = obtenerOperacionPorId;
            _actualizarOperacion = actualizarOperacion;
            _finalizarOperacion = finalizarOperacion;
            _obtenerDocumentosPorOperacion = obtenerDocumentosPorOperacion;
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
        [HttpGet]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerOperaciones.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET /api/operacion/filtros?clienteId=1&tipoOperacionId=2&estado=EnProceso&fechaDesde=2024-01-01&fechaHasta=2024-12-31
        [HttpGet("filtros")]
        [Authorize(Roles = "Despachante,Admin")]
        public IActionResult ObtenerTodosConFiltros(
            [FromQuery] int? clienteId,
            [FromQuery] int? tipoOperacionId,
            [FromQuery] string? estado,
            [FromQuery] DateTime? fechaDesde,
            [FromQuery] DateTime? fechaHasta)
        {
            try
            {
                var resultado = _obtenerOperacionesConFiltros.Ejecutar(
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

        // PATCH /api/operacion/{id}/datos-aduaneros
        [HttpPatch("{id}/datos-aduaneros")]
        [Authorize(Roles = "Admin, Despachante")]
        public IActionResult ActualizarOperacion(int id, [FromBody] ActualizarDatosAduanerosDTO dto)
        {
            try
            {
                var resultado = _actualizarOperacion.Ejecutar(id, dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

        // PATCH /api/operacion/{id}/finalizar
        [HttpPatch("{id}/finalizar")]
        [Authorize(Roles = "Admin, Despachante")]
        public IActionResult FinalizarOperacion(int id)
        {
            try
            {
                var resultado = _finalizarOperacion.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }

        }

        // GET /api/operacion/{id}/documentos
        [HttpGet("{id}/documentos")]
        [Authorize(Roles = "Admin, Despachante")]
        public IActionResult ObtenerDocumentosPorOperacion(int id)
        {
            try
            {
                var resultado = _obtenerDocumentosPorOperacion.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
