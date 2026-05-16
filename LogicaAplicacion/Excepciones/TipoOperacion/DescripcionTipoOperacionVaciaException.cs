using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.TipoOperacion
{
    public class DescripcionTipoOperacionVaciaException : ClaseExcepcion
    {
        public DescripcionTipoOperacionVaciaException() : base("La descripción es obligatoria.") { }
    }
}
