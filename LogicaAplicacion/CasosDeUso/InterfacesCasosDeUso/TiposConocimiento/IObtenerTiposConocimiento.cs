using Compartido.DTOs.TipoConocimiento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.TipoConocimiento.TipoConocimientoDTO;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TiposConocimiento
{
    public interface IObtenerTiposConocimiento
    {
        IEnumerable<TipoConocimientoListadoDTO> Ejecutar();
    }
}
