using Compartido.DTOs.Cliente;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente
{
    public interface IModificarCliente
    {
        ModificarClienteDTO Ejecutar(int id, ModificarClienteDTO dto);
    }
}
