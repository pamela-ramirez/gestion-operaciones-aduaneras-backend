using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioOperacion : IRepositorio<Operacion>
    {

        // Busca una operación por su número de carpeta.
        Operacion FindByNroCarpeta(string nroCarpeta);

        // Retorna todas las operaciones asociadas a un cliente específico.
        IEnumerable<Operacion> FindByClienteId(int clienteId);

        // Retorna todas las operaciones filtradas por estado.
        IEnumerable<Operacion> FindByEstado(EstadoOperacion estado);

        // Verifica si ya existe una operación con ese número de carpeta.
        // Se usa para validar unicidad antes de crear o actualizar.
        // El parámetro excluirId permite ignorar la operación actual al editar.
        bool ExisteNroCarpeta(string nroCarpeta, int? excluirId = null);

        // Verifica si ya existe una operación con ese número de DUA.
        bool ExisteNroDua(string nroDua, int? excluirId = null);
    }
}
