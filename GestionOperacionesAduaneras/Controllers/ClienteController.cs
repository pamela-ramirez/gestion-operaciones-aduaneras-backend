using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using Microsoft.AspNetCore.Mvc;

namespace GestionOperacionesAduaneras.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICrearCliente _crearCliente;
        private readonly IObtenerClientes _obtenerClientes;
        private readonly IObtenerClientePorId _obtenerClientePorId;
        private readonly IModificarCliente _modificarCliente;
        private readonly IEliminarCliente _eliminarCliente;

        public ClienteController(
            ICrearCliente crearCliente,
            IObtenerClientes obtenerClientes,
            IObtenerClientePorId obtenerClientePorId,
            IModificarCliente modificarCliente,
            IEliminarCliente eliminarCliente)
        {
            _crearCliente = crearCliente;
            _obtenerClientes = obtenerClientes;
            _obtenerClientePorId = obtenerClientePorId;
            _modificarCliente = modificarCliente;
            _eliminarCliente = eliminarCliente;
        }

        // POST /api/cliente - Crear cliente
        [HttpPost]
        public IActionResult Crear([FromBody] CrearClienteDTO dto)
        {
            try
            {
                var resultado = _crearCliente.Ejecutar(dto);
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

        // GET /api/cliente - Obtener todos los clientes
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            try
            {
                var resultado = _obtenerClientes.Ejecutar();
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { mensaje = ex.Message });
            }
        }

        // GET /api/cliente/{id} - Obtener cliente por ID
        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            try
            {
                var resultado = _obtenerClientePorId.Ejecutar(id);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }

    
        // PUT /api/cliente/{id} - Modificar cliente
        [HttpPut("{id}")]
        public IActionResult Modificar(int id, [FromBody] ModificarClienteDTO dto)
        {
            try
            {
                var resultado = _modificarCliente.Ejecutar(id, dto);
                return Ok(resultado);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensaje = ex.Message });
            }
        }
    

        // DELETE /api/cliente/{id} - Eliminar cliente
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int id)
        {
            try
            {
                _eliminarCliente.Ejecutar(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { mensaje = ex.Message });
            }
        }
    }
}
