namespace LogicaNegocio.Excepciones.Roles
{
    public class RolDebeSerAsignadoException : ClassException
    {
        public RolDebeSerAsignadoException() : base("Debe asignar un rol al usuario.")
        {
        }
    }
}
