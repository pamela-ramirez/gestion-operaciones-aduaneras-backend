using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class NombreUsuarioSuperaCaracteresException : ClassException
    {
        public NombreUsuarioSuperaCaracteresException() : base("El nombre no puede superar 100 caracteres.") { }
    }
}
