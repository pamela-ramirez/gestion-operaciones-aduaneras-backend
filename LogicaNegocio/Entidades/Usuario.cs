using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public abstract class Usuario : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public Email Email { get; set; }
        public Password Password { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; }

        //agregue estos nuevos atributos porque el frontend los necesita
        //para mostrar la fecha de creación del usuario, y
        //para saber si es su primer login o no, y
        //también para mostrar el estado del usuario (activo o inactivo)
        public DateTime FechaCreacion { get; set; }
        public bool PrimerLogin { get; set; }
        public EstadoUsuario Estado { get; set; }

        public Usuario() { }

        public Usuario(string nombre, string apellido, Email email, Password password, Rol rol)
        {
            Nombre = nombre;
            Apellido = apellido;
            Email = email;
            Password = password;
            Rol = rol;
            FechaCreacion = DateTime.Now;
            PrimerLogin = true; // Por defecto, es el primer login al crear el usuario}
            Estado = EstadoUsuario.Pendiente;
        }

        public virtual void Validar()
        {
            if (string.IsNullOrWhiteSpace(Nombre))
                throw new NombreVacioUsuarioException();

            if (Nombre.Length > 100)
                throw new NombreUsuarioSuperaCaracteresException();

            if (string.IsNullOrWhiteSpace(Apellido))
                throw new ApellidoVacioUsuarioException();

            if (Apellido.Length > 100)
                throw new ApellidoUsuarioSuperaCaracteresException();

            if (Password == null)
                throw new PasswordObligatoriaException();

            if (Rol == null)
                throw new RolObligatorioException();

            if (FechaCreacion == default)
                throw new FechaCreacionInvalidaException();
        }
    }
}
