using LogicaAccesoDatos.Contexto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioTipoConocimiento : IRepositorioTipoConocimiento
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioTipoConocimiento(GestionOperacionesDbContext context)
        {
            _context = context;
        }

        public void Add(TipoConocimiento item)
        {
            _context.TiposConocimiento.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoConocimiento> FindAll()
        {
            return _context.TiposConocimiento.ToList();
        }

        public TipoConocimiento FindById(int id)
        {
            return _context.TiposConocimiento.FirstOrDefault(t => t.Id == id);
        }

        public void Update(TipoConocimiento item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
