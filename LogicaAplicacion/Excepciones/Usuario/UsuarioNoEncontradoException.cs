using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class UsuarioNoEncontradoException: ClaseExcepcion
    {
        public UsuarioNoEncontradoException() : base("Usuario no encontrado.")
        {
        }
    }
}
