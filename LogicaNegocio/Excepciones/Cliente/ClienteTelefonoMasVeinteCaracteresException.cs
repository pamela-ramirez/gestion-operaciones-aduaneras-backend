namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteTelefonoMasVeinteCaracteresException : ClassException
    {
        public ClienteTelefonoMasVeinteCaracteresException() : base("El teléfono no puede superar 20 caracteres.") { }
    }
}
