using Compartido.DTOs.Cliente;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface IObtenerClientes
    {
        IEnumerable<ClienteDTO> Ejecutar();
    }
}
