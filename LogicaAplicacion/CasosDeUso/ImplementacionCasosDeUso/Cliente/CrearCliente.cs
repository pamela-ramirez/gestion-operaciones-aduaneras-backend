using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaNegocio.InterfacesRepositorios;
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
        //private readonly IClienteService _clienteService;
        private readonly IRepositorioCliente _clienteRepo;

        public CrearCliente(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public CrearClienteRespuestaDTO Ejecutar(CrearClienteDTO dto)
        {
            
            return _clienteRepo.Add(dto);
        }
    }
}
