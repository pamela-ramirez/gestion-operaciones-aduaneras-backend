using Compartido.DTOs.Documento;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Documento;
using LogicaAplicacion.Excepciones.Documento;
using LogicaAplicacion.Excepciones.Operacion;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DocumentoController : ControllerBase
    {
        private readonly ICrearDocumento _crearDocumento;
        private readonly IObtenerDocumentoPorId _obtenerDocumentoPorId;

        public DocumentoController(ICrearDocumento crearDocumento,
            IObtenerDocumentoPorId obtenerDocumentoPorId)
        {
            _crearDocumento = crearDocumento;
            _obtenerDocumentoPorId = obtenerDocumentoPorId;
        }

        // POST /api/documento
        [HttpPost]
        [Authorize(Roles = "Despachante,Admin")]
        public async Task<IActionResult> CrearDocumento([FromForm] CrearDocumentoDTO dto)
        {
         /*   try
            {
                var resultado = await _crearDocumento.Ejecutar(dto);
                // 201 Created + el documento fue creado
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
         */


            try
            {
                var resultado = await _crearDocumento.Ejecutar(dto);
                return CreatedAtAction(
                    nameof(ObtenerPorId),
                    new { id = resultado.Id },
                    resultado
                );
            }
            catch (OperacionNoEncontradaException ex)
            {
                return NotFound(ex.Message);
            }
            catch (FormatoNoPermitidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // GET /api/documento/{id}
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerDocumentoPorId.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
