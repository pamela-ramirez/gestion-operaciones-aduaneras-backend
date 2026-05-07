namespace LogicaNegocio.Excepciones.Operacion
{
    public class NumCarpetaObligatorioException : ClassException
    {
        public NumCarpetaObligatorioException() : base("El número de carpeta es obligatorio.") { }
    }
}
