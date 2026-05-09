using Compartido.DTOs.Despachante;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;

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
        public static DespachanteDTO ToDespachanteDTO(Despachante despachante)
        {
            return new DespachanteDTO
            {
                Nombre = despachante.Nombre,
                Apellido = despachante.Apellido,
                Email = despachante.Email.Valor,
                Codigo = despachante.Codigo
            };
        }
    }
}
