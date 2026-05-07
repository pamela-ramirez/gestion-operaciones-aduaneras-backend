namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ApellidoUsuarioSuperaCaracteresException : ClassException
    {
        public ApellidoUsuarioSuperaCaracteresException() : base("El apellido no puede superar 100 caracteres.") { }
    }
}
