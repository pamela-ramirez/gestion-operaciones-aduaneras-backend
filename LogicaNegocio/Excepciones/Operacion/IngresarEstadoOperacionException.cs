namespace LogicaNegocio.Excepciones.Operacion
{
    public class IngresarEstadoOperacionException : ClassException
    {
        public IngresarEstadoOperacionException() : base("El estado es obligatorio.") { }
    }
}
