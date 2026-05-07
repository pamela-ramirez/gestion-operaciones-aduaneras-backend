namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteDireccionExcesoCaracteresException : ClassException
    {
        public ClienteDireccionExcesoCaracteresException() : base("La dirección no puede superar 300 caracteres.") { }
    }
}
