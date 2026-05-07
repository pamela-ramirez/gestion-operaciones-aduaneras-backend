namespace LogicaNegocio.Excepciones.Usuarios
{
    public class UsuarioEmailVacioException : ClassException
    {
        public UsuarioEmailVacioException() : base("El email no puede estar vacío.")
        {
        }
    }
}
