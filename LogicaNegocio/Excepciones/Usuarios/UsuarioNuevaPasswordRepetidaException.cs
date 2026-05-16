using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioNuevaPasswordRepetidaException : ClassException
    {
        public UsuarioNuevaPasswordRepetidaException() : base("La nueva contraseña no puede ser igual a la anterior.") { }
    }
}
