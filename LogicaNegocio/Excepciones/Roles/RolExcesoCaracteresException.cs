namespace LogicaNegocio.Excepciones.Roles
{
    public class RolExcesoCaracteresException : ClassException
    {
        public RolExcesoCaracteresException() : base("El nombre del rol no puede superar 100 caracteres.") { }
    }
}
