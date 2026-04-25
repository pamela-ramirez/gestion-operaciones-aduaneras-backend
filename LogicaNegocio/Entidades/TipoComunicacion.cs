using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class TipoComunicacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }


        public int AsuntoId { get; set; }
        public Asunto Asunto { get; set; }

        public TipoComunicacion() { }
        public TipoComunicacion(string descripcion, string contenido, Asunto asunto)
        {
            Descripcion = descripcion;
            Contenido = contenido;
            Asunto = asunto;
        }
    }
}
