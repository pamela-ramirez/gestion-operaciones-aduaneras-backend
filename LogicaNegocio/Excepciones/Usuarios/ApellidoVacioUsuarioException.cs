namespace LogicaNegocio.Excepciones.Usuarios
{
    public class ApellidoVacioUsuarioException : ClassException
    {
        public ApellidoVacioUsuarioException() : base("El apellido no puede estar vacío.") { }
    }
}
