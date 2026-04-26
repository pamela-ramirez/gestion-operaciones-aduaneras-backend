using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cliente:Usuario
    {
        public string Rut { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }


        public Cliente() { }

        public Cliente(string nombre, string apellido, Email email, Password password, Rol rol, string rut, string telefono, string? direccion) : base(nombre, apellido, email, password, rol)
        {
            this.Rut = rut;
            this.Telefono = telefono;
            this.Direccion = direccion;
        }


    }
}
