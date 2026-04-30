using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Roles
{
    public class RolDatosIncorrectosException : ClassException
    {
        public RolDatosIncorrectosException() : base("Los datos recibidos no son correctos.") { }
    }
}
