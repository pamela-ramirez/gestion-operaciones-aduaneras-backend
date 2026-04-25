using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal MontoPagado { get; set; }
        public string Estado { get; set; } = string.Empty; //ver
        public string? RutaComprobante { get; set; }
        public string? IdTransaccion { get; set; } // para Mercado Pago RF-21


        public TipoPago Tipo { get; set; }


        public int LiquidacionId { get; set; }
        public Liquidacion Liquidacion { get; set; } = null!;


        public ValidacionPago? Validacion { get; set; }

        public Pago() { }

        public Pago(decimal montoPagado, DateTime fechaPago,
            Liquidacion liquidacion, TipoPago tipo)
        {
            MontoPagado = montoPagado;
            FechaPago = fechaPago;
            Liquidacion = liquidacion;
            Tipo = tipo;
            Estado = "Pendiente";
        }
    }

}

