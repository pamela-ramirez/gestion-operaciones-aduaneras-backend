using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class NombreUsuarioSuperaCaracteresException : ClaseExcepcion
    {
        public NombreUsuarioSuperaCaracteresException() : base("El nombre no puede superar 100 caracteres.") { }
    }
}
