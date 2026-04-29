using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class ObtenerClientes : IObtenerClientes
    {
        private readonly IClienteService _clienteService;

        public ObtenerClientes(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public IEnumerable<ClienteRespuestaDTO> Ejecutar()
        {
            return _clienteService.ObtenerClientes();
        }
    }
}
