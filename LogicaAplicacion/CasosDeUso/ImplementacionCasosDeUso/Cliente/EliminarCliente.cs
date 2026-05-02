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
    public class EliminarCliente : IEliminarCliente
    {

        private readonly IRepositorioCliente _clienteRepo;

        public EliminarCliente(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }
        public void Ejecutar(int id)
        {
            _clienteRepo.Delete(id);
        }


        //private readonly IClienteService _clienteService;
        // public EliminarCliente(IClienteService clienteService)
        // {
        //      _clienteService = clienteService;
        //  }
        // public void Ejecutar(int id)
        // {
        //_clienteService.EliminarCliente(id);
        // }

    }
}
