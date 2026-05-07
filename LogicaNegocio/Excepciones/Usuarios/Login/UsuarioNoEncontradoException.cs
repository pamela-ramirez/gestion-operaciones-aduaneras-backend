namespace LogicaNegocio.Excepciones.Usuarios.Login
{
    public class UsuarioNoEncontradoException : UsuarioException
    {
        public UsuarioNoEncontradoException() : base("El usuario no fue encontrado.") { }
    }
}
