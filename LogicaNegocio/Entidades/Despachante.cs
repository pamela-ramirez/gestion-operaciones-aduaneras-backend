using LogicaNegocio.Excepciones.Despachante;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Despachante : Usuario, IValidable
    {
        //codigo de despachante
        public string? Codigo { get; set; }

        public Despachante() { }

        public Despachante(string nombre, string apellido, Email email, Password password, Rol rol, string? codigo = null) : base(nombre, apellido, email, password, rol)
        {
            this.Codigo = codigo;
            Validar();
        }

        public override void Validar()
        {
            // valida todo lo heredado de Usuario
            base.Validar();

            if (Codigo != null && Codigo.Length > 30)
                throw new CodigoDespachanteExcesoCaracteresException();
        }
    }
}
