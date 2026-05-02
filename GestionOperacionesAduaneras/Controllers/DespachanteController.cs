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

        public DespachanteController(ICrearDespachante crearDespachante)
        {
            _crearDespachante = crearDespachante;
        }

        // POST /api/despachante - Crear despachante
        [HttpPost]
        public IActionResult Crear([FromBody] CrearDespachanteDTO dto)
        {
            try
            {
                var resultado = _crearDespachante.Ejecutar(dto);
                return CreatedAtAction(
                    nameof(Crear),
                    new { id = resultado.Id },
                    resultado
                );
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }

    }
}
