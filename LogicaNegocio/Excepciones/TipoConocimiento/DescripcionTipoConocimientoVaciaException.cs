using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.TipoConocimiento
{
    public class DescripcionTipoConocimientoVaciaException : ClassException
    {
        public DescripcionTipoConocimientoVaciaException() : base("La descripción no puede ser vacía.") { }
    }
}
