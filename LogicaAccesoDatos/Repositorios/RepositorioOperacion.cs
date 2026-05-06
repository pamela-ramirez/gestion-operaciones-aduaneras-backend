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
    public class RepositorioOperacion : IRepositorioOperacion
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioOperacion(GestionOperacionesDbContext context)
        {
            _context = context;
        }

        public void Add(Operacion item)
        {
            _context.Operaciones.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var operacion = FindById(id);
            if (operacion == null)
                throw new Exception("Operación no encontrada.");

            _context.Operaciones.Remove(operacion);
            _context.SaveChanges();
        }

        public bool ExisteNroCarpeta(string nroCarpeta, int? excluirId = null)
        {
            throw new NotImplementedException();
        }

        public bool ExisteNroDua(string nroDua, int? excluirId = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacion> FindAll()
        {
            return _context.Operaciones
                .Include(o => o.TipoOperacion)
                .Include(o => o.Cliente)
                .Include(o => o.TipoConocimiento)
                .ToList();
        }

        public IEnumerable<Operacion> FindByClienteId(int clienteId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Operacion> FindByEstado(EstadoOperacion estado)
        {
            throw new NotImplementedException();
        }

        public Operacion FindById(int id)
        {
            return _context.Operaciones
                .Include(o => o.TipoOperacion)
                .Include(o => o.Cliente)
                    .ThenInclude(c => c.Rol)
                .Include(o => o.TipoConocimiento)
                .Include(o => o.Liquidaciones)
                .Include(o => o.Documentos)
                .FirstOrDefault(o => o.Id == id);
        }

        public Operacion FindByNroCarpeta(string nroCarpeta)
        {
            throw new NotImplementedException();
        }

        public void Update(Operacion item, int id)
        {
            _context.SaveChanges();
        }
    }
}
