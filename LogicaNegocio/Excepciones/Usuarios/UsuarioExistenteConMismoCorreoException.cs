namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioExistenteConMismoCorreoException : ClassException
    {
        public UsuarioExistenteConMismoCorreoException() : base("Ya existe un usuario con ese correo electrónico.") { }
    }
}
