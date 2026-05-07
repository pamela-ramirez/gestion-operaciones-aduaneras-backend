using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioEmailFormatoInvalidoException : ClassException
    {
        public UsuarioEmailFormatoInvalidoException() : base("El formato del email es inválido.")
        {
        }
    }
}
