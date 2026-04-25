using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Comunicacion
    {
        public int Id { get; set; }
        public string Contenido { get; set; } = string.Empty;
        public DateTime FechaEnvio { get; set; } = DateTime.Now;
        public bool Enviado { get; set; } = false;


        public int UsuarioEnvioId { get; set; }
        public Usuario UsuarioEnvio { get; set; } = null!;

 
        public int? OperacionId { get; set; } // puede ser null para cotizacion RN-13.1
        public Operacion? Operacion { get; set; }


        public int TipoComunicacionId { get; set; }
        public TipoComunicacion TipoComunicacion { get; set; } = null!;


        public int AsuntoId { get; set; }
        public Asunto Asunto { get; set; } = null!;

        public Comunicacion() { }

        public Comunicacion(string contenido, Usuario usuarioEnvio,
            TipoComunicacion tipoComunicacion, Asunto asunto,
            Operacion? operacion)
        {
            Contenido = contenido;
            UsuarioEnvio = usuarioEnvio;
            TipoComunicacion = tipoComunicacion;
            Asunto = asunto;
            Operacion = operacion;
            FechaEnvio = DateTime.Now;
            Enviado = false;
        }
    }
}
