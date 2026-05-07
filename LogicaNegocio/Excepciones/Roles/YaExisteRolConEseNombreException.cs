namespace LogicaNegocio.Excepciones.Roles
{
    public class YaExisteRolConEseNombreException : ClassException
    {
        public YaExisteRolConEseNombreException() : base("Ya existe un rol con ese nombre.") { }
    }
}
