using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class NumCarpetaSuperaCaracteresException : ClassException
    {
        public NumCarpetaSuperaCaracteresException() : base("El número de carpeta no puede superar los 50 caracteres.") { }
    }
}
