namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteConOperacionesActivasException : ClassException
    {
        public ClienteConOperacionesActivasException() : base("El cliente no puede ser eliminado porque tiene operaciones activas.") { }
    }
}
