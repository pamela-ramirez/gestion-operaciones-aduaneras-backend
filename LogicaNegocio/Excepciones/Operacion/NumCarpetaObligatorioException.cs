using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class NumCarpetaObligatorioException : ClassException
    {
        public NumCarpetaObligatorioException() : base("El número de carpeta es obligatorio.") { }
    }
}
