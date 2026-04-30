using System.Security.Cryptography;
using System.Text;

namespace GestionOperacionesAduaneras.Servicios
{
    public class PasswordGenerator
    {
        private const string Mayus = "ABCDEFGHJKLMNPQRSTUVWXYZ";
        private const string Minus = "abcdefghijkmnopqrstuvwxyz";
        private const string Numeros = "23456789";
        private const string Simbolos = "!@$?*#";

        public string Generar(int length = 10)
        {
            var chars = Mayus + Minus + Numeros + Simbolos;

            var result = new StringBuilder();

            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] data = new byte[length];

                rng.GetBytes(data);

                for (int i = 0; i < length; i++)
                {
                    var idx = data[i] % chars.Length;
                    result.Append(chars[idx]);
                }
            }

            return AsegurarComplejidad(result.ToString());
        }

        private string AsegurarComplejidad(string password)
        {
            bool tieneMayus = password.Any(char.IsUpper);
            bool tieneMinus = password.Any(char.IsLower);
            bool tieneNum = password.Any(char.IsDigit);
            bool tieneSimbolo = password.Any(c => "!@$?*#".Contains(c));

            if (tieneMayus && tieneMinus && tieneNum && tieneSimbolo)
                return password;

            // si no cumple, regeneramos
            return Generar(password.Length);
        }
    }
}