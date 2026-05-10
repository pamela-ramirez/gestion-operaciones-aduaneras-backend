using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.TipoConocimiento
{
    public class TipoConocimientoNoEncontradoException : ClaseExcepcion
    {
        public TipoConocimientoNoEncontradoException() : base("No se encontró el tipo de conocimiento.")
        {
        }
    }
}
