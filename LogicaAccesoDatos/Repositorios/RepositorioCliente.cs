using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly GestionOperacionesDbContext _context;
        // Brinda mayor seguridad si es readonly, ya que no se puede acceder a el y hacer cambios

        public RepositorioCliente(GestionOperacionesDbContext context)
        {
            _context = context;
        }

        public void Add(Cliente item)
        {
            _context.Clientes.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Cliente cliente = FindById(id);
            if (cliente == null)
            {
                throw new UsuarioNoEncontradoException();
            }
            _context.Clientes.Remove(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente item, int id)
        {
            Cliente clienteExistente = FindById(id);
            if (clienteExistente == null)
                throw new UsuarioNoEncontradoException();

            clienteExistente.Nombre = item.Nombre;
            clienteExistente.Apellido = item.Apellido;
            clienteExistente.Email = item.Email;
            clienteExistente.Telefono = item.Telefono;
            clienteExistente.Direccion = item.Direccion;
            clienteExistente.RazonSocial = item.RazonSocial;
            clienteExistente.Rut = item.Rut;

            _context.SaveChanges();
        }

        // Cuando hacemos update de un cliente, podemos usar el excluirClienteId,
        // para no comparar, en la busqueda, el rut de ese cliente consigo mismo
        public bool ExisteRut(string rut, int? excluirClienteId = null)
        {
            return _context.Clientes
                .Any(c => c.Rut.Valor == rut &&
                     (excluirClienteId == null || c.Id != excluirClienteId));
        }

        public IEnumerable<Cliente> FindAll()
        {
            return _context.Clientes
                .Include(c => c.Rol)
                .ToList();
        }

        public Cliente FindById(int id)
        {
            return _context.Clientes
                .Include(c => c.Rol)
                .FirstOrDefault(c => c.Id == id);
        }

        public Cliente FindByRut(string rut)
        {
            return _context.Clientes
                .Include(c => c.Rol)
                .FirstOrDefault(c => c.Rut.Valor == rut);
        }

        public bool TieneOperacionesActivas(int ClienteId)
        {
            return _context.Operaciones
                .Any(o => o.ClienteId == ClienteId && o.Estado != EstadoOperacion.Finalizado);
        }
    }
}
