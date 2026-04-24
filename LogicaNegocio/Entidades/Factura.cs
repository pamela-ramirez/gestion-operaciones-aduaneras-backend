using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Factura
    {
        public int Id { get; set; }
        public string RutaArchivo { get; set; }
        public DateTime FechaCarga { get; set; } = DateTime.Now;

        public int LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; } = null!;
        public Factura() { }

        public Factura(string rutaArchivo, Liquidacion liquidacion)
        {
            RutaArchivo = rutaArchivo;
            Liquidacion = liquidacion;
            FechaCarga = DateTime.Now;
        }
    }
}
