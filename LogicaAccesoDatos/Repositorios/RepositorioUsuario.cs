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
    public class RepositorioUsuario : IRepositorioUsuario
    {
        public GestionOperacionesDbContext Contexto { get; set; }

        public RepositorioUsuario(GestionOperacionesDbContext contexto)
        {
            Contexto = contexto;
        }


        public void Add(Usuario item)
        {
            Contexto.Usuarios.Add(item);
            Contexto.SaveChanges();

        }

        public void Delete(int id)
        {
            var usuario = Contexto.Usuarios.Find(id);
            if (usuario != null)
            {
                Contexto.Usuarios.Remove(usuario);
                Contexto.SaveChanges();
            }
        }

        // Traer todos los usuarios
        public IEnumerable<Usuario> FindAll()
        {
            return Contexto.Usuarios
                .Include(u => u.Rol)
                .ToList();
        }

        public Usuario FindById(int id)
        {
            return Contexto.Usuarios
                .Include(u => u.Rol)
                .FirstOrDefault(u => u.Id == id);
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await Contexto.Usuarios // Accede a la tabla de usuarios
           .Include(u => u.Rol) // Asegura que el rol se cargue junto con el usuario
           .FirstOrDefaultAsync(u => u.Email.Valor == email); // Busca el usuario por su email
        }

        public void Update(Usuario item, int id)
        {
            var usuarioExistente = Contexto.Usuarios.Find(id);
            if(usuarioExistente != null)
            {
                usuarioExistente.Nombre = item.Nombre;
                usuarioExistente.Apellido = item.Apellido;
                usuarioExistente.Email = item.Email;
                usuarioExistente.RolId = item.RolId;
                Contexto.SaveChanges();
            }
        }
    }
}
