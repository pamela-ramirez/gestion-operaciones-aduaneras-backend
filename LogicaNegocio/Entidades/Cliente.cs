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

        public Cliente() { }

        public Cliente(string nombre, string apellido, Email email, Password password, Rol rol, string rut) : base(nombre, apellido, email, password, rol)
        {
            this.Rut = rut;
        }


    }
}
