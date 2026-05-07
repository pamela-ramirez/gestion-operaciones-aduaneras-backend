namespace LogicaNegocio.Excepciones.Roles
{
    public class RolDatosIncorrectosException : ClassException
    {
        public RolDatosIncorrectosException() : base("Los datos recibidos no son correctos.") { }
    }
}
