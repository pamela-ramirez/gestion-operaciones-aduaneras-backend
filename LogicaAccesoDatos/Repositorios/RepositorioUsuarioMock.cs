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
    public class RepositorioUsuarioMock : IRepositorioUsuario
    {
        private List<Usuario> usuarios = new List<Usuario>
    {
        /*new Usuario
        {
            Id = 1,
            Nombre = "Pamela",
            Apellido = "Test",
            Email = new Email("pamela@test.com"),
            Password = new Password("Abc123!!"),
            RolId = 1,
            Rol = new Rol("Admin")
        }*/
    };

        public void Add(Usuario item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuario> FindAll()
        {
            throw new NotImplementedException();
        }

        public Usuario FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario?> GetByEmail(string email)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Email.Valor == email);
            return Task.FromResult(usuario);
        }

        public void Update(Usuario item, int id)
        {
            throw new NotImplementedException();
        }
    }
}
