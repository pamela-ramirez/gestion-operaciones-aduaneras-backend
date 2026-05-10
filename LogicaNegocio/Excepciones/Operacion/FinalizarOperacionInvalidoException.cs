using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Excepciones.Operacion
{
    public class FinalizarOperacionInvalidoException : ClassException
    {
        public FinalizarOperacionInvalidoException() : 
            base("No se puede finalizar la operación. Asegúrese de que todos los datos aduaneros estén completos y que la operación esté en proceso.")
        {
        }
    }
}
