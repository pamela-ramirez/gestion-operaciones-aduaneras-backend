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
        public TipoOperacion TipoOperacion { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }

        // Datos que se completan DESPUES (RF-08)
        // son opcionales al inicio, por eso tienen ?
        public string? NroDua { get; set; }
        public int? TipoConocimientoId { get; set; }
        public TipoConocimiento? TipoConocimiento { get; set; }
        public int? NroConocimiento { get; set; }


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

        public Operacion(string nroCarpeta, TipoOperacion tipoOperacion, Cliente cliente)
        {
            NroCarpeta = nroCarpeta;
            TipoOperacion = tipoOperacion;
            Cliente = cliente;
            Estado = EstadoOperacion.Iniciado;
            FechaRegistro = DateTime.Now;
        }

        // Metodo para actualizar datos aduaneros, cuando el despachante completa la informacion
        public void ActualizarDatosAduaneros(string nroDua,
            TipoConocimiento tipoConocimiento, int nroConocimiento)
        {
            NroDua = nroDua;
            TipoConocimiento = tipoConocimiento;
            NroConocimiento = nroConocimiento;

            ActualizarEstado();
        }

        private void ActualizarEstado()
        {
            if (Estado == EstadoOperacion.Finalizado)
                return;

            // Si tiene todos los datos aduaneros completos
            if (NroDua != null &&
                TipoConocimiento != null &&
                NroConocimiento != null)
            {
                Estado = EstadoOperacion.EnProceso;
            }
            // Si le faltan datos
            else
            {
                Estado = EstadoOperacion.DocumentacionPendiente;
            }
        }

        // El estado Finalizado se asigna manualmente
        public void Finalizar()
        {
            Estado = EstadoOperacion.Finalizado;
        }



    }
}
