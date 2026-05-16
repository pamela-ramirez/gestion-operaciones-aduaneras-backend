using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ConsentimientoYaAceptadoUsuarioException : ClassException
    {
        public ConsentimientoYaAceptadoUsuarioException() : base ("El usuario ya aceptó el consentimiento.") { }
    }
}
