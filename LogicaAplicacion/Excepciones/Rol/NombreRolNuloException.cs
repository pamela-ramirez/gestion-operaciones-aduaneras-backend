using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Rol
{
    public class NombreRolNuloException : ClaseExcepcion
    {
        public NombreRolNuloException() : base("El nombre del rol no puede ser nulo.")
        {
        }
    }
}
