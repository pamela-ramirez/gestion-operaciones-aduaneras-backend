using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public enum TipoNotificacion
    {
        LiquidacionProximaVencer = 1,
        LiquidacionVencida = 2,
        CorreoEnviado = 3,
        PagoPendienteValidar = 4
    }
}
