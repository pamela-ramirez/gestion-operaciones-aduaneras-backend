using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Excepciones
{
    public class UsuarioNoEncontradoException : ClaseGenericaException
    {   
        public UsuarioNoEncontradoException() : base("Usuario no encontrado.")
        {
        }
    }
}
