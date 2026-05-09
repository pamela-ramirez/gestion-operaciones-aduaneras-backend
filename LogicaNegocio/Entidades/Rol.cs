using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.Entidades
{
    public class Rol : IEntity, IValidable
    {
        public int Id { get; set; }
        public string NombreRol { get; set; }
        public Rol() { }

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
            if (string.IsNullOrWhiteSpace(NombreRol))
            {
                throw new RolSinNombreException();
            }

            if(NombreRol.Length > 100)
            {
                throw new RolExcesoCaracteresException();
            }
        }

    }
}
