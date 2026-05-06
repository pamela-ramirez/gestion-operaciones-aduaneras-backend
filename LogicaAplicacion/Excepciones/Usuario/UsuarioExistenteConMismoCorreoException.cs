using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class UsuarioExistenteConMismoCorreoException : ClaseExcepcion
    {
        public UsuarioExistenteConMismoCorreoException() : base("Ya existe un usuario con ese correo electrónico.") { }
    }
}
