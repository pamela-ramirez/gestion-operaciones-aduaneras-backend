using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Despachante : Usuario
    {
        //codigo de despachante
        public string? Codigo { get; set; }


        public Despachante() { }

        public Despachante(string nombre, string apellido, Email email, Password password, Rol rol) : base(nombre, apellido, email, password, rol)
        {

        }


    }
}
