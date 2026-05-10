using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TiposConocimiento;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TipoConocimientoController : ControllerBase
    {
        private readonly IObtenerTiposConocimiento _obtenerTiposConocimiento;

        public TipoConocimientoController(IObtenerTiposConocimiento obtenerTiposConocimiento)
        {
            _obtenerTiposConocimiento = obtenerTiposConocimiento;
        }

        // GET /api/tipoconocimiento
        [HttpGet]
        [Authorize(Roles = "Admin, Despachante")]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerTiposConocimiento.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    }
}
