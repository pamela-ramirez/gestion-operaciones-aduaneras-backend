using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class UsuarioNuevaPasswordRepetidaException : ClaseExcepcion
    {
        public UsuarioNuevaPasswordRepetidaException() : base("No puede repetir contraseña")
        {
        }
    }
}
