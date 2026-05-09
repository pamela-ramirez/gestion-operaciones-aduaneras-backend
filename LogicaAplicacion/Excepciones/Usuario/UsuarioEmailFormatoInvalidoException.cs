using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class UsuarioEmailFormatoInvalidoException : ClaseExcepcion
    {
        public UsuarioEmailFormatoInvalidoException() : base("El formato del email es inválido.")
        {
        }
    }
}
