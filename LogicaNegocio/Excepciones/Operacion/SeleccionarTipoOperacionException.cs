namespace LogicaNegocio.Excepciones.Operacion
{
    public class SeleccionarTipoOperacionException : ClassException
    {
        public SeleccionarTipoOperacionException() : base("Debe seleccionar un tipo de operación.") { }
    }
}
