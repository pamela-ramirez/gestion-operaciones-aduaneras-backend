namespace LogicaNegocio.Excepciones.Rut
{
    public class RutNumerosIgualesException : ClassException
    {
        public RutNumerosIgualesException() : base("El RUT no puede tener todos los dígitos iguales.")
        {
        }
    }
}
