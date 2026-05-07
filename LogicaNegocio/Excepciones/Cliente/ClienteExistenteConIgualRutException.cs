namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteExistenteConIgualRutException : ClassException
    {
        public ClienteExistenteConIgualRutException() : base("Ya existe un cliente con ese RUT.") { }
    }
}
