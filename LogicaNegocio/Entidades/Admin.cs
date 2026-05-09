using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Admin : Usuario
    {
        public Admin() { }

        public Admin(
            string nombre,
            string apellido,
            Email email,
            Password password,
            Rol rol
        ) : base(nombre, apellido, email, password, rol)
        {
        }
    }
}