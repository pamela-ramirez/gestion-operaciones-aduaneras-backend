namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioEmailFormatoInvalidoException : ClassException
    {
        public UsuarioEmailFormatoInvalidoException() : base("El formato del email es inválido.")
        {
        }
    }
}
