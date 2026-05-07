using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ApellidoVacioUsuarioException : ClassException
    {
        public ApellidoVacioUsuarioException() : base("El apellido no puede estar vacío.") { }
    }
}
