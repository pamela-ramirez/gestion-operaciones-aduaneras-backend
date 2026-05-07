namespace LogicaNegocio.Excepciones.Usuarios.Login
{
    public class CredencialesInvalidasException : UsuarioException
    {
        public CredencialesInvalidasException() : base("Las credenciales ingresadas no son válidas.") { }
    }
}
