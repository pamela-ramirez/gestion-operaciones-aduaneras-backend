namespace LogicaNegocio.Excepciones.Usuarios
{
    public class NombreUsuarioSuperaCaracteresException : ClassException
    {
        public NombreUsuarioSuperaCaracteresException() : base("El nombre no puede superar 100 caracteres.") { }
    }
}
