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
    public class ObtenerClientePorId : IObtenerClientePorId
    {
        private readonly IRepositorioCliente _clienteRepo;
        public ObtenerClientePorId(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ClienteDTO Ejecutar(int id)
        {
            var cliente = _clienteRepo.FindById(id);
            if (cliente == null)
            {
                throw new Exception("Cliente no encontrado");
            }

            return new ClienteDTO
            {
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email.Valor,
                RazonSocial = cliente.RazonSocial,
                Rut = cliente.Rut,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion
            };
        }

        // TODO Pasar el new ClienteDTO a un mapeador para mapearlo a un DTO
    }
}
