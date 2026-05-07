using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios.Login
{
    public class UsuarioNoEncontradoException : UsuarioException
    {
        public UsuarioNoEncontradoException() : base("El usuario no fue encontrado.") { }
    }
}
