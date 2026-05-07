using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoOperacion
{
    public class DescripcionTipoOperacionVaciaException : ClassException
    {
        public DescripcionTipoOperacionVaciaException() : base("La descripción del tipo de operación no puede estar vacía."){ }
    }
}
