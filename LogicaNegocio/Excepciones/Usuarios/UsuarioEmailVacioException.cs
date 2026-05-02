using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioEmailVacioException : ClassException
    {
        public UsuarioEmailVacioException() : base("El email no puede estar vacío.")
        {
        }
    }
}
