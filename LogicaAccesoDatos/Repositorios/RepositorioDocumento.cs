using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Excepciones;
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
    public class RepositorioDocumento : IRepositorioDocumento
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioDocumento(GestionOperacionesDbContext context)
        {
            _context = context;
        }
        public void Add(Documento item)
        {
            _context.Documentos.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Documento doc = FindById(id);
            if (doc == null)
                throw new DocumentoNoEncontradoException();
            _context.Documentos.Remove(doc);
            _context.SaveChanges();
        }

        public IEnumerable<Documento> FindAll()
        {
            throw new NotImplementedException();
        }

        public Documento FindById(int id)
        {
            return _context.Documentos.Include(d => d.Operacion)
                .FirstOrDefault(d => d.Id == id);
        }

        public void Update(Documento item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
