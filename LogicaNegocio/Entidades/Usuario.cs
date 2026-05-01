using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public abstract class Usuario:IEntity
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public Email Email { get; set; } 
        public Password Password { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string apellido, Email email, Password password, Rol rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Rol = rol;
            Validar();
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new NombreVacioUsuarioException();

            if (Nombre.Length > 100)
                throw new NombreUsuarioSuperaCaracteresException();

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new ApellidoVacioUsuarioException();

            if (Apellido.Length > 100)
                throw new ApellidoUsuarioSuperaCaracteresException();
        }
    }
}
