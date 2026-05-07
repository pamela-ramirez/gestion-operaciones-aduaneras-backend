namespace LogicaNegocio.Excepciones.Operacion
{
    public class ClienteSeleccionadoInvalidoException : ClassException
    {
        public ClienteSeleccionadoInvalidoException() : base("Debe seleccionar un cliente válido.") { }
    }
}
