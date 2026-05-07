using Compartido.DTOs.TipoOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion
{
    public interface ICrearTipoOperacion
    {
        TipoOperacionListadoDTO Ejecutar(CrearTipoOperacionDTO dto);
    }
}
