using Compartido.DTOs.Despachante;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante
{
    public interface ICrearDespachante
    {
        CrearDespachanteRespuestaDTO Ejecutar(CrearDespachanteDTO dto);
    }
}
