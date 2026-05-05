using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class ModificarCliente : IModificarCliente
    {
        private readonly IRepositorioCliente _clienteRepo;
        public ModificarCliente(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ModificarClienteDTO Ejecutar(int id, ModificarClienteDTO dto)
        {
            var cliente = _clienteRepo.FindById(id);

            if (cliente == null)
                throw new Exception("Cliente no encontrado");

            // Update parcial
            if (!string.IsNullOrWhiteSpace(dto.Nombre))
                cliente.Nombre = dto.Nombre;

            if (!string.IsNullOrWhiteSpace(dto.Apellido))
                cliente.Apellido = dto.Apellido;

            if (!string.IsNullOrWhiteSpace(dto.Email))
                cliente.Email = new Email(dto.Email);

            if (!string.IsNullOrWhiteSpace(dto.Telefono))
                cliente.Telefono = dto.Telefono;

            _clienteRepo.Update(cliente, id);

            return dto;
        }

    }
}
