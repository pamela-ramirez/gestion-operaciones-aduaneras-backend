using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class EstadoInvalidoException : ClassException
    {
        public EstadoInvalidoException() : base("El estado del usuario es inválido.") { }
    }
}
