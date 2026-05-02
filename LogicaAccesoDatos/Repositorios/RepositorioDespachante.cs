using LogicaAccesoDatos.Contexto;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioDespachante : IRepositorioDespachante
    {
        private readonly GestionOperacionesDbContext _context;
        public RepositorioDespachante(GestionOperacionesDbContext context)
        {
            _context = context;
        }
        public void Add(Despachante item)
        {
            _context.Despachantes.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExisteEmail(string email)
        {
            return _context.Despachantes
                .Any(d => d.Email.Valor == email);
        }

        public IEnumerable<Despachante> FindAll()
        {
            throw new NotImplementedException();
        }

        public Despachante FindById(int id)
        {
            return _context.Despachantes
                .FirstOrDefault(d => d.Id == id);
        }

        public void Update(Despachante item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
