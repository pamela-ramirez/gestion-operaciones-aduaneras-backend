using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class DetalleLiquidacion
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public decimal Monto { get; set; }

        public int LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; } = null!;

        public DetalleLiquidacion() { }
        public DetalleLiquidacion(string descripcion, decimal monto)
        {
            Descripcion = descripcion;
            Monto = monto;
        }
    }
}
