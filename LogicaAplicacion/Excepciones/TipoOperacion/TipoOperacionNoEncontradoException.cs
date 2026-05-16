using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.TipoOperacion
{
    public class TipoOperacionNoEncontradoException : ClaseExcepcion
    {
        public TipoOperacionNoEncontradoException(): base ("No se encontró el tipo de operación con ese ID.") { }
    }
}
