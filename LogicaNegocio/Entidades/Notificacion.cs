using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Notificacion
    {
        public int Id { get; set; }
        public string Mensaje { get; set; } = string.Empty;
        public DateTime FechaCreacion { get; set; } = DateTime.Now;
        public bool Leida { get; set; } = false;
        public TipoNotificacion Tipo { get; set; }


        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; } // Destinatario


        public int? ComunicacionId { get; set; } // opcional RF-33
        public Comunicacion? Comunicacion { get; set; }

        public Notificacion() { }

        public Notificacion(string mensaje, TipoNotificacion tipo,
            Cliente cliente, Comunicacion? comunicacion)
        {
            Mensaje = mensaje;
            Tipo = tipo;
            Cliente = cliente;
            Comunicacion = comunicacion;
            FechaCreacion = DateTime.Now;
            Leida = false;
        }
    }
}
