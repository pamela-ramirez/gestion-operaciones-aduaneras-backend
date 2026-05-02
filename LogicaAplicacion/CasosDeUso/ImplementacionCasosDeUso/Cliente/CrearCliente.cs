using Compartido.DTOs.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente
{
    public class CrearCliente : ICrearCliente
    {
        private readonly IRepositorioCliente _clienteRepo;
        private readonly IRepositorioRol _rolRepo;

        public CrearCliente(IRepositorioCliente clienteRepo, IRepositorioRol rolRepo    )
        {
            _clienteRepo = clienteRepo;
            _rolRepo = rolRepo;
        }
        public CrearClienteRespuestaDTO Ejecutar(CrearClienteDTO dto)
        {
            //validar si existe email

            var existe = _clienteRepo.ExisteRut(dto.Rut);
            if (existe)
                throw new Exception("Ya existe un cliente con ese RUT");

            var rolCliente = _rolRepo.FindById(3);

            var username = $"{dto.Email.Split('@')[0]}";
            var passwordTemporal = "Despacho100!";

            var cliente = ClienteMapper.ToEntity(dto, rolCliente);

            _clienteRepo.Add(cliente);

            return ClienteMapper.ToDTO(cliente, username, passwordTemporal);
            
        }
    }
}
