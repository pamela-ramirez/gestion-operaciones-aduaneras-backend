using Compartido.DTOs.Cliente;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface ICrearCliente
    {
        CrearClienteRespuestaDTO Ejecutar(CrearClienteDTO dto);
    }
}
