namespace LogicaNegocio.Excepciones.Rut
{
    public class RutSoloNumerosException : ClassException
    {
        public RutSoloNumerosException() : base("El RUT debe contener solo números (sin puntos ni guiones).") { }
    }
}
