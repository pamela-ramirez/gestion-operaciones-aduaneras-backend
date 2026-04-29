using Compartido.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IClienteService
    {
        IEnumerable<ClienteRespuestaDTO> ObtenerClientes();
        ClienteRespuestaDTO ObtenerClientePorId(int id);
        ClienteRespuestaDTO CrearCliente(CrearClienteDTO dto);
        ClienteRespuestaDTO ModificarCliente(int id, ModificarClienteDTO dto);
        void EliminarCliente(int id);
    }
}
