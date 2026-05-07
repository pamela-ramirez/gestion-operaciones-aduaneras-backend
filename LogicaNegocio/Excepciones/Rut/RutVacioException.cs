namespace LogicaNegocio.Excepciones.Rut
{
    public class RutVacioException : ClassException
    {
        public RutVacioException() : base("El RUT no puede estar vacío.") { }
    }
}
