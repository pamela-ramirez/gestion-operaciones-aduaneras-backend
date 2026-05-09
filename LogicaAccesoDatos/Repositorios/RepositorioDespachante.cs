using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.EntityFrameworkCore;

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
            Despachante despachante = FindById(id);
            if (despachante == null)
            {
                throw new UsuarioNoEncontradoException();
            }
            _context.Despachantes.Remove(despachante);
            _context.SaveChanges();
        }

        public bool ExisteEmail(string email)
        {
            return _context.Despachantes
                .Any(d => d.Email.Valor == email);
        }

        public IEnumerable<Despachante> FindAll()
        {
            return _context.Despachantes
                .Include(d => d.Rol)
                .ToList();
        }

        public Despachante FindById(int id)
        {
            return _context.Despachantes
                .FirstOrDefault(d => d.Id == id);
        }

        public void Update(Despachante item, int id)
        {
            Despachante despachanteExistente = FindById(id);
            if (despachanteExistente == null)
            {
                throw new UsuarioNoEncontradoException();
            }

            despachanteExistente.Nombre = item.Nombre;
            despachanteExistente.Apellido = item.Apellido;
            despachanteExistente.Email = item.Email;
            despachanteExistente.Codigo = item.Codigo;

            _context.SaveChanges();
        }
    }
}
