using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RutaArchivo { get; set; }
        public string Formato { get; set; } // PDF, JPG, PNG
        public DateTime FechaCarga { get; set; } = DateTime.Now;

        public int OperacionId { get; set; }
        public Operacion Operacion { get; set; }

        public Documento() { }
        public Documento(string nombre, string rutaArchivo,
            string formato, Operacion operacion)
        {
            Nombre = nombre;
            RutaArchivo = rutaArchivo;
            Formato = formato;
            Operacion = operacion;
            FechaCarga = DateTime.Now;
        }
    }
}
