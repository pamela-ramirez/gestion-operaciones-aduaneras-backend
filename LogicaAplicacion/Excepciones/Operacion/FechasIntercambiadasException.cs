using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.Operacion
{
    public class FechasIntercambiadasException: ClaseExcepcion
    {
        public FechasIntercambiadasException() : base("La fecha desde no puede ser mayor que la fecha hasta.")
        {
        }
    }
}
