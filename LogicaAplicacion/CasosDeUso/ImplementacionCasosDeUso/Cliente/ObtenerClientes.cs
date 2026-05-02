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
    public class ObtenerClientes : IObtenerClientes
    {
       
        private readonly IRepositorioCliente _clienteRepo;

        public ObtenerClientes(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public IEnumerable<ClienteDTO> Ejecutar()
        {
            var clientes = _clienteRepo.FindAll();
            return clientes.Select(c => new ClienteDTO
            {
                Nombre = c.Nombre,
                Apellido = c.Apellido,
                Email = c.Email.Valor,
                RazonSocial = c.RazonSocial,
                Rut = c.Rut,
                Telefono = c.Telefono,
                Direccion = c.Direccion
            }).ToList();
        }



        // private readonly IClienteService _clienteService;

        // public ObtenerClientes(IClienteService clienteService)
        //{
        //     _clienteService = clienteService;
        // }
        // public IEnumerable<ClienteRespuestaDTO> Ejecutar()
        // {
        //    return _clienteService.ObtenerClientes();
        //}
    }
}
