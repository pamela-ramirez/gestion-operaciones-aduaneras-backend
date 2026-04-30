using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioExistenteConMismoCorreoException : ClassException
    {
        public UsuarioExistenteConMismoCorreoException() : base("Ya existe un usuario con ese correo electrónico.") { }
    }
}
