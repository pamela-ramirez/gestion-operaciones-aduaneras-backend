using LogicaAccesoDatos.Contexto;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioRol : IRepositorioRol
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioRol(GestionOperacionesDbContext context)
        {
            _context = context;
        }

        public void Add(Rol item)
        {
            _context.Roles.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var rol = FindById(id);
            if (rol == null)
            {
                throw new RolNoEncontradoException();
            }
            _context.Roles.Remove(rol);
            _context.SaveChanges();
        }

        public void Update(Rol item, int id)
        {
            var rolExistente = FindById(id);
            if (rolExistente == null)
            {
                throw new RolNoEncontradoException();
            }

            rolExistente.NombreRol = item.NombreRol;
            _context.SaveChanges();
        }

        public Rol FindById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Rol> FindAll()
        {
            return _context.Roles.ToList();
        }

        public Rol FindByNombre(string nombreRol)
        {
            return _context.Roles.FirstOrDefault(r => r.NombreRol == nombreRol);
        }
    }
}