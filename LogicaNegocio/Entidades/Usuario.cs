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
        } 

    }
}
