namespace LogicaNegocio.Excepciones.Roles
{
    public class RolNoEncontradoException : ClassException
    {
        public RolNoEncontradoException() : base("Rol no encontrado.") { }
    }
}
