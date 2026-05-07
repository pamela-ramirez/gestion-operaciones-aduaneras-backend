namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteNoEncontradoException : ClassException
    {
        public ClienteNoEncontradoException() : base("Cliente no encontrado.") { }
    }
}
