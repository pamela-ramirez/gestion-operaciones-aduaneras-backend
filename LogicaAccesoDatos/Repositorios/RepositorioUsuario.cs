using LogicaAccesoDatos.Contexto;
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
                throw new Exception("Usuario no encontrado.");
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
                throw new Exception("Usuario no encontrado.");

            usuario.Nombre = item.Nombre;
            usuario.Apellido = item.Apellido;
            usuario.Email = new Email(item.Email.Valor);
            usuario.RolId = item.RolId;

            _context.SaveChanges();
        }

        // Metodo update para actualizar el estado del usuario a activo, y para actualizar la contraseña, en el primer login
        /*     public void UpdateEstado(Usuario item, int id)
             {
                 var usuarioExistente = FindById(id);
                 if (usuarioExistente != null)
                 {
                     usuarioExistente.Estado = "Activo";
                     _context.SaveChanges();
                 }
             }
        */
        public void UpdatePassword(Usuario item, int id)
        {
            var usuario = FindById(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            usuario.Password = item.Password;
            usuario.PrimerLogin = false;

            _context.SaveChanges();
        }

        public void AceptarConsentimeinto(int id)
        {
            var usuario = FindById(id);

            if (usuario == null)
                throw new Exception("Usuario no encontrado.");

            usuario.Estado = "Activo";

            _context.SaveChanges();
        }
    }
}
