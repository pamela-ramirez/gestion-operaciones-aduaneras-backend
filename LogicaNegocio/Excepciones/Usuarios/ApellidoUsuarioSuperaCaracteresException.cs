using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ApellidoUsuarioSuperaCaracteresException : ClassException
    {
        public ApellidoUsuarioSuperaCaracteresException() : base("El apellido no puede superar 100 caracteres.") { }
    }
}
