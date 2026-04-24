using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Liquidacion
    {
        public int Id { get; set; }
        public DateTime FechaEnvio { get; set; }
        public DateTime FechaVenc { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal SaldoPendiente { get; set; }
        public EstadoLiquidacion Estado { get; set; }


        public int OperacionId { get; set; }
        public Operacion Operacion { get; set; }


        public ICollection<DetalleLiquidacion> Detalle { get; set; }
            = new List<DetalleLiquidacion>();


        public ICollection<Pago> Pagos { get; set; }
            = new List<Pago>();


        public Factura? Factura { get; set; }

        public Liquidacion() { }

        public Liquidacion(Operacion operacion,
            List<DetalleLiquidacion> detalle)
        {
            Operacion = operacion;
            Detalle = detalle;
            FechaEnvio = DateTime.Now;

            // RN-18.3: vencimiento automatico a 30 dias
            FechaVenc = DateTime.Now.AddDays(30);

            // RN-18.2: monto total se calcula automaticamente
            MontoTotal = detalle.Sum(d => d.Monto);
            SaldoPendiente = MontoTotal;

            // RN-18.4: estado inicial Pendiente
            Estado = EstadoLiquidacion.Pendiente;
        }

        // RN-23: actualizacion automatica del estado
        public void ActualizarEstado()
        {
            if (SaldoPendiente == 0)
                Estado = EstadoLiquidacion.Pagado;
            else if (SaldoPendiente < MontoTotal)
                Estado = EstadoLiquidacion.ParcialmentePagado;
            else
                Estado = EstadoLiquidacion.Pendiente;
        }
    }
}
