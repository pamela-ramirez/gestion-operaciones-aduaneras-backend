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
    public class ModificarCliente : IModificarCliente
    {
        private readonly IRepositorioCliente _clienteRepo;
        public ModificarCliente(IRepositorioCliente clienteRepo)
        {
            _clienteRepo = clienteRepo;
        }

        public ModificarClienteDTO Ejecutar(int id, ModificarClienteDTO dto)
        {
            return new ModificarClienteDTO {
                Nombre = dto.Nombre,
                Apellido = dto.Apellido,
                Email = dto.Email,
                Telefono = dto.Telefono,
                    Direccion = dto.Direccion,
                    Rut = dto.Rut,
                    RazonSocial = dto.RazonSocial,
                    Password = dto.Password
            };
        }




        //private readonly IClienteService _clienteService;
        // public ModificarCliente(IClienteService clienteService)
        // {
        //     _clienteService = clienteService;
        // }
        //public ClienteRespuestaDTO Ejecutar(int id,ModificarClienteDTO dto)
        // {
        //    return _clienteService.ModificarCliente(id, dto);
        // }
    }
}
