namespace LogicaNegocio.Excepciones.Rut
{
    public class RutNoValidoException : ClassException
    {
        public RutNoValidoException() : base("El RUT no es válido (fallo en dígito verificador).") { }
    }
}
