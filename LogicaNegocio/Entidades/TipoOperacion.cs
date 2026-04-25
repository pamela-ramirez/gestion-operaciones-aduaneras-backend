using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class TipoOperacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoOperacion() { }
        public TipoOperacion(string descripcion)
        {
            Descripcion = descripcion;
        }
    }
}
