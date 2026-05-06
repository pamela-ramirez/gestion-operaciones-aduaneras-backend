using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class ApellidoUsuarioSuperaCaracteresException : ClaseExcepcion
    {
        public ApellidoUsuarioSuperaCaracteresException() : base("El apellido no puede superar 100 caracteres.") { }
    }
}
