namespace LogicaNegocio.Entidades
{
    public class TipoConocimiento
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoConocimiento() { }
        public TipoConocimiento(string descripcion)
        {
            Descripcion = descripcion;
        }
    }
}
