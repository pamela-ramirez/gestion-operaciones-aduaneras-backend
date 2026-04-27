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
    public class ObtenerClientePorId : IObtenerClientePorId
    {
        private readonly IClienteService _clienteService;
        public ObtenerClientePorId(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public ClienteRespuestaDTO Ejecutar(int id)
        {
            return _clienteService.ObtenerClientePorId(id);
        }
    }
}
