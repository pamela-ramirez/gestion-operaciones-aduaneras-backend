using LogicaNegocio.Excepciones.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    [ComplexType]
    public record Password
    {
        [StringLength(50, MinimumLength = 6)]
        public string Valor { get; init; }
        public Password(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if (Valor.Trim().Length < 6)
            {
                throw new UsuarioException("La password debe tener por lo menos 6 caracteres");
            }
            if (!PasswordEsValida())
            {
                throw new UsuarioException("La password no cumple con las restricciones indicadas, " +
                    "debe tener por lo menos un número, una letra minúscula, una letra mayúscula y un signo de puntuación (. ; !)");
            }
        }

        private bool PasswordEsValida()
        {
            int i = 0;
            bool esMinuscula = false;
            bool esMayuscula = false;
            bool tieneDigito = false;
            bool esValido = false;
            char[] puntuacion = { '.', ';', '!' };
            bool tienePuntuacion = false;

            while (i < Valor.Length && !esValido)
            {
                if (char.IsLetter(Valor[i]))
                {
                    if (char.IsLower(Valor[i]))
                    {
                        esMinuscula = true;
                    }
                    else
                    {
                        esMayuscula = true;
                    }

                }
                else if (char.IsDigit(Valor[i]))
                {
                    tieneDigito = true;
                }

                foreach (char p in puntuacion)
                {
                    if (Valor.Contains(p))
                    {
                        tienePuntuacion = true;
                    }
                }


                if (esMinuscula && esMayuscula && tieneDigito && tienePuntuacion)
                {
                    esValido = true;
                }
                i++;
            }


            return esValido;
        }
    }
}

