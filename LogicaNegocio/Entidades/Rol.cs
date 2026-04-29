using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Rol:IEntity
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }
        private Rol() { }

        public Rol(string nombreRol)
        {
            NombreRol = nombreRol;
            Validar();
        }

        public Rol(int id)
        {
            Id = id;
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(NombreRol))
            {
                throw new RolSinNombreException();
            }
        }

    }
}
