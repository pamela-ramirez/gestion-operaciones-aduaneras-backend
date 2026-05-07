namespace LogicaNegocio.Excepciones.Usuarios
{
    public class NombreVacioUsuarioException : ClassException
    {
        public NombreVacioUsuarioException() : base("El nombre no puede estar vacío.") { }
    }
}
