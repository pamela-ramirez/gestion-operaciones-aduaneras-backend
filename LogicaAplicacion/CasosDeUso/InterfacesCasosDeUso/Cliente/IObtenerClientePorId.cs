using Compartido.DTOs.Cliente;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface IObtenerClientePorId
    {
        ClienteDTO Ejecutar(int id);
    }
}
