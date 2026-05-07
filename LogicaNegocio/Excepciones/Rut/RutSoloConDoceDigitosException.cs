namespace LogicaNegocio.Excepciones.Rut
{
    public class RutSoloConDoceDigitosException : ClassException
    {
        public RutSoloConDoceDigitosException() : base("El RUT debe tener exactamente 12 dígitos.") { }
    }
}
