using Compartido.DTOs.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaNegocio.Entidades;
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

        public RolController(
            ICrearRol crearRol,
            IObtenerRoles obtenerRoles)
        {
            _crearRol = crearRol;
            _obtenerRoles = obtenerRoles;
           
        }

        // POST /api/rol
        [HttpPost]
        public IActionResult Crear([FromBody] RolDTO dto)
        {
            try
            {
                var rol = _crearRol.Ejecutar(dto);
                return Ok(rol);
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

    
    }
}
