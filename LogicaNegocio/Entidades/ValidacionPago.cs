using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class ValidacionPago
    {
        public int Id { get; set; }
        public DateTime FechaValidacion { get; set; } = DateTime.Now;
        public bool Aprobado { get; set; }
        public string? MotivoRechazo { get; set; }


        public int UsuarioValidacionId { get; set; }
        public Usuario UsuarioValidacion { get; set; } = null!;


        public int PagoId { get; set; }
        public Pago Pago { get; set; } = null!;

        public ValidacionPago() { }

        public ValidacionPago(bool aprobado, Usuario usuarioValidacion,
            Pago pago, string? motivoRechazo)
        {
            Aprobado = aprobado;
            UsuarioValidacion = usuarioValidacion;
            Pago = pago;
            MotivoRechazo = motivoRechazo;
            FechaValidacion = DateTime.UtcNow;
        }
    }
}
