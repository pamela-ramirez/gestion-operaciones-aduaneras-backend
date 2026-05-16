using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Excepciones;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.ValueObject;
using Microsoft.EntityFrameworkCore;

namespace LogicaAccesoDatos.Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly GestionOperacionesDbContext _context;

        public RepositorioUsuario(GestionOperacionesDbContext context)
        {
            _context = context;
        }

        public void Add(Usuario item)
        {
            _context.Usuarios.Add(item);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = FindById(id);
            if (usuario == null)
            {
                throw new UsuarioNoEncontradoException();
            }
            _context.Usuarios.Remove(usuario);
            _context.SaveChanges();
        }

        // Traer todos los usuarios
        public IEnumerable<Usuario> FindAll()
        {
            return _context.Usuarios
                .Include(u => u.Rol)
                .ToList();
        }

        public Usuario FindById(int id)
        {
            return _context.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.Id == id);
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _context.Usuarios // Accede a la tabla de usuarios
           .Include(u => u.Rol) // Asegura que el rol se cargue junto con el usuario
           .FirstOrDefaultAsync(u => u.Email.Valor == email); // Busca el usuario por su email
        }

        public void Update(Usuario item, int id)
        {
            var usuario = FindById(id);

            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            _context.SaveChanges();
        }

        public bool ExisteEmail(string email)
        {
            return _context.Usuarios
                .Any(u => u.Email.Valor == email);
        }
    }
}
