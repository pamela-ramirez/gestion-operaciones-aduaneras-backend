using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class ApellidoVacioUsuarioException : ClaseExcepcion
    {
        public ApellidoVacioUsuarioException() : base("El apellido no puede estar vacío.") { }
    }
}
