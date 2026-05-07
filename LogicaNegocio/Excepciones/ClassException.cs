namespace LogicaNegocio.Excepciones
{
    public class ClassException : Exception
    {
        public ClassException() { }

        public ClassException(string message) : base(message) { }

        public ClassException(string message, Exception innerException) : base(message, innerException) { }

    }
}
