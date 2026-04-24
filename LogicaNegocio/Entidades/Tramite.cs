using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Tramite
    {
        public int Id { get; set; }
        public int NroDua { get; set; }
        public int NroConocimiento { get; set; }
        public DateTime FechaInicio { get; set; } = DateTime.Now;

        
        public int TipoConocimientoId { get; set; }
        public TipoConocimiento TipoConocimiento { get; set; }

        
        public int OperacionId { get; set; }
        public Operacion Operacion { get; set; }

        public Tramite() { }
        public Tramite(int nroDua, int nroConocimiento,
            TipoConocimiento tipoConocimiento, Operacion operacion)
        {
            NroDua = nroDua;
            NroConocimiento = nroConocimiento;
            TipoConocimiento = tipoConocimiento;
            Operacion = operacion;
            FechaInicio = DateTime.Now;
        }
    }
}
