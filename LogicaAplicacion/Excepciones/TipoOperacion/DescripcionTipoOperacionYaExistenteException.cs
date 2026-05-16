using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.Excepciones.TipoOperacion
{
    public class DescripcionTipoOperacionYaExistenteException : ClaseExcepcion
    {
        public DescripcionTipoOperacionYaExistenteException() : base("Ya existe un tipo de operación con la misma descripción.") { }
    }
}
