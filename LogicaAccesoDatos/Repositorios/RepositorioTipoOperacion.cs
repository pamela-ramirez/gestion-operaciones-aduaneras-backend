using LogicaAccesoDatos.Contexto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TipoOperacion> FindAll()
        {
            throw new NotImplementedException();
        }

        public TipoOperacion FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TipoOperacion item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
