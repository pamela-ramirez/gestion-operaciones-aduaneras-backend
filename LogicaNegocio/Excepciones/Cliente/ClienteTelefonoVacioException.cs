namespace LogicaNegocio.Excepciones.Cliente
{
    public class ClienteTelefonoVacioException : ClassException
    {
        public ClienteTelefonoVacioException() : base("El teléfono no puede estar vacío.") { }
    }
}
