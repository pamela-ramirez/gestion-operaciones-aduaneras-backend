using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios.Login
{
    public class CredencialesInvalidasException : UsuarioException
    {
        public CredencialesInvalidasException() : base("Las credenciales ingresadas no son válidas.") { }
    }
}
