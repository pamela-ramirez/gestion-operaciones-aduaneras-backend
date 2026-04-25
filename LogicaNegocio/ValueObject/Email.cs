using LogicaNegocio.Excepciones.Usuarios;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.ValueObject
{
    //[ComplexType]
    public record Email
    {
        public string Valor { get; init; }

        public Email(string valor)
        {
            Valor = valor;
            Validar();
        }
        private void Validar()
        {
            if ((Valor.Contains("@")) == false || Valor.IndexOf("@") == 0 || Valor.IndexOf("@") == Valor.Length - 1)
            {
                throw new UsuarioException("Formato de Email no valido");
            }

            //nos falta validar que no exista otro mail
        }
    }
}

