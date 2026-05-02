using Compartido.DTOs.Despachante;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Mappers
{
    public class DespachanteMapper
    {
        public static Despachante ToEntity(CrearDespachanteDTO dto, Rol rol)
        {
            return new Despachante(
               dto.Nombre,
               dto.Apellido,
               new Email(dto.Email),
               new Password("Despacho100!"), // password default
               rol
            );
        }

        public static CrearDespachanteRespuestaDTO ToDTO(Despachante despachante, string username, string passwordTemporal)
        {
            return new CrearDespachanteRespuestaDTO
            {
                Id = despachante.Id,
                Nombre = despachante.Nombre,
                Apellido = despachante.Apellido,
                Email = despachante.Email.Valor,
                Username = username,
                PasswordTemporal = passwordTemporal
            };
        }
    }
}
