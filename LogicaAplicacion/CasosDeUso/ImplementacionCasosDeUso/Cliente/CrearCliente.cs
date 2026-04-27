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
    public class CrearCliente : ICrearCliente
    {
        private readonly IClienteService _clienteService;

        public CrearCliente(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public ClienteRespuestaDTO Ejecutar(CrearClienteDTO dto)
        {
            return _clienteService.CrearCliente(dto);
        }
    }
}
