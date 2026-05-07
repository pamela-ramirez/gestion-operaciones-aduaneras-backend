using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Cliente : Usuario
    {
        public string Rut { get; set; } = string.Empty;
        public string RazonSocial { get; set; } = string.Empty;
        public string? Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }


        public Cliente() { }

        public Cliente(string nombre, string apellido, Email email, Password password, Rol rol, string rut, string razonSocial, string telefono, string? direccion) : base(nombre, apellido, email, password, rol)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Telefono = telefono;
            this.Direccion = direccion;
        }


    }
}
