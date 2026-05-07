using Compartido.DTOs.Operacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Operacion
{
    public interface IObtenerOperacionPorId
    {
        OperacionRespuestaDTO Ejecutar(int operacionId);
    }
}
