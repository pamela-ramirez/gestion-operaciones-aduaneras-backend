using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesServicios;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestionOperacionesAduaneras.Servicios
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        // IConfiguration permite leer el appsettings.json
        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerarToken(Usuario usuario)
        {
            // 1. Definís qué información va DENTRO del token (claims)
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Email, usuario.Email.Valor),
                new Claim(ClaimTypes.Role, usuario.Rol.NombreRol),
               // agregar más claims como el nombre completo o rut o nombre de usuario o nombre de empresa
            };

            // 2. Creás la clave secreta con la que se firma el token
            var clave = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_config["Jwt:Clave"]!)
            );

            // 3. Definís el algoritmo de firma
            var credenciales = new SigningCredentials(clave, SecurityAlgorithms.HmacSha256);

            // 4. Armás el token con toda la info
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Emisor"],
                audience: _config["Jwt:Audiencia"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8), // expira en 8 horas
                signingCredentials: credenciales
            );

            // 5. Lo convertís a string (eso es lo que le mandás al cliente)
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}