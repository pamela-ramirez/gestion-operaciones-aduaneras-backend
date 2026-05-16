using Compartido.DTOs.Cliente;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface IModificarCliente
    {
        ClienteDTO Ejecutar(int id, ModificarClienteDTO dto);
    }
}
