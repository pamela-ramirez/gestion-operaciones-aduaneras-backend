using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Usuario
{
    public class NombreVacioUsuarioException : ClaseExcepcion
    {
        public NombreVacioUsuarioException() : base("El nombre no puede estar vacío.") { }
    }
}
