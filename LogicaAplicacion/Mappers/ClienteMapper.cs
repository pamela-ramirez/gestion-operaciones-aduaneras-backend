using Compartido.DTOs.Cliente;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public static class ClienteMapper
    {
        public static Cliente ToEntity(CrearClienteDTO dto, Rol rol)
        {
            return new Cliente(
               dto.Nombre,
               dto.Apellido,
               new Email(dto.Email),
               new Password("Despacho100!"), // password default
               rol,
               dto.Rut,
               dto.RazonSocial,
               dto.Telefono,
               dto.Direccion
           );
        }

        public static CrearClienteRespuestaDTO ToDTO(Cliente cliente, string username, string passwordTemporal)
        {
            return new CrearClienteRespuestaDTO
            {
                Id = cliente.Id,
                Nombre = cliente.Nombre,
                Apellido = cliente.Apellido,
                Email = cliente.Email.Valor,
                Rut = cliente.Rut,
                RazonSocial = cliente.RazonSocial,
                Telefono = cliente.Telefono,
                Direccion = cliente.Direccion,
                Username = username,
                PasswordTemporal = passwordTemporal
            };
        }
    }
}
