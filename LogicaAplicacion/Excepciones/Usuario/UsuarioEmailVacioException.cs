using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class UsuarioEmailVacioException : ClaseExcepcion
    {
        public UsuarioEmailVacioException() : base("El email no puede estar vacío.")
        {
        }
    }
}
