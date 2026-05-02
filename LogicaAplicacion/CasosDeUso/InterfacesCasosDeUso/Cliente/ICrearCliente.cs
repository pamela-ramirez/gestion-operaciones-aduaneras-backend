using Compartido.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface ICrearCliente
    {
        CrearClienteRespuestaDTO Ejecutar(CrearClienteDTO dto);
    }
}
