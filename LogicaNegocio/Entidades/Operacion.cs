using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Operacion
    {
        public int Id { get; set; }
        public string NroCarpeta { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.Now;
        public EstadoOperacion Estado { get; set; }

        public int TipoOperacionId { get; set; }
        public TipoOperacion Tipo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }


        public Tramite Tramite { get; set; }

        public ICollection<Liquidacion> Liquidaciones { get; set; }
            = new List<Liquidacion>();

        public ICollection<Documento> Documentos { get; set; }
            = new List<Documento>();

        public ICollection<Comunicacion> Comunicaciones { get; set; }
            = new List<Comunicacion>();


        /*¿Por qué se usa ICollection con Entity Framework?
        Entity Framework cuando carga los datos de la base de datos, 
        no siempre usa una List. Internamente puede usar otros tipos de 
        colecciones más eficientes según la situación. Si vos forzás que sea una List, 
        le estás limitando esa flexibilidad.Entity Framework queda obligado a usar List
        aunque no sea lo mas eficiente*/
        public Operacion() { }

        public Operacion(string nroCarpeta, TipoOperacion tipo, Cliente cliente)
        {
            NroCarpeta = nroCarpeta;
            Tipo = tipo;
            Cliente = cliente;
            Estado = EstadoOperacion.Iniciado;
            FechaRegistro = DateTime.Now;
        }

        // RN-07: actualizacion automatica del estado
        public void ActualizarEstado()
        {
            if (Estado == EstadoOperacion.Finalizado)
                return;

            if (Tramite != null &&
                Tramite.NroDua != 0 &&
                Tramite.TipoConocimiento != null &&
                Tramite.NroConocimiento != 0)
            {
                Estado = EstadoOperacion.EnProceso;
            }
            else
            {
                Estado = EstadoOperacion.DocumentacionPendiente;
            }
        }

        // RN-07.5: el estado Finalizado se asigna manualmente
        public void Finalizar()
        {
            Estado = EstadoOperacion.Finalizado;
        }



    }
}
