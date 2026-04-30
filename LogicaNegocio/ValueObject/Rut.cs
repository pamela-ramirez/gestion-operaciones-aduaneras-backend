using LogicaNegocio.Excepciones.Rut;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    public record Rut
    {
        public string Valor { get; }

        public Rut(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))

                throw new RutVacioException();

            if (!valor.All(char.IsDigit))
                throw new RutSoloNumerosException();

            if (valor.Length != 12)
                throw new RutSoloConDoceDigitosException();

            if (valor.Distinct().Count() == 1)
                throw new RutNumerosIgualesException();

            if (!ValidarDigitoVerificador(valor))
                throw new RutNoValidoException();

            Valor = valor;
        }

        private static bool ValidarDigitoVerificador(string rut)
        {
            int[] multiplicadores = { 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };

            int suma = 0;

            for (int i = 0; i < 11; i++)
            {
                int digito = rut[i] - '0';
                suma += digito * multiplicadores[i];
            }

            int resto = suma % 11;
            int digitoCalculado = 11 - resto;

            if (digitoCalculado == 11)
                digitoCalculado = 0;
            else if (digitoCalculado == 10)
                digitoCalculado = 1;

            int digitoReal = rut[11] - '0';

            return digitoCalculado == digitoReal;
        }

        public override string ToString() => Valor;
    }
}
