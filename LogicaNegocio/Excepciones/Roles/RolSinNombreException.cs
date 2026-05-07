namespace LogicaNegocio.Excepciones.Roles
{
    public class RolSinNombreException : ClassException
    {
        public RolSinNombreException() : base("El rol debe tener un nombre.") { }
    }
}
