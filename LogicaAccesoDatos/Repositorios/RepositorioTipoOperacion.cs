using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioTipoOperacion : IRepositorioTipoOperacion
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioTipoOperacion(GestionOperacionesDbContext context)
        {
            _context = context;
        }
        public void Add(TipoOperacion item)
        {
            _context.TiposOperacion.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var tipo = FindById(id);
            if (tipo == null)
                throw new TipoOperacionNoEncontradoException();

            _context.TiposOperacion.Remove(tipo);
            _context.SaveChanges();
        }

        public IEnumerable<TipoOperacion> FindAll()
        {
            return _context.TiposOperacion.ToList();
        }

        public TipoOperacion FindByDescripcion(string descripcion)
        {
            return _context.TiposOperacion
                .FirstOrDefault(t => t.Descripcion == descripcion);
        }

        public TipoOperacion FindById(int id)
        {
            return _context.TiposOperacion.FirstOrDefault(t => t.Id == id);

        }

        public void Update(TipoOperacion item, int id)
        {
            _context.SaveChanges();
        }
    }
}
