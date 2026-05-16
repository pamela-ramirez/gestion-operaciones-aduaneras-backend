using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.InterfacesEntidades;
using LogicaNegocio.ValueObject;

namespace LogicaNegocio.Entidades
{
    public class Cliente : Usuario, IValidable
    {
        public Rut? Rut { get; set; }
        public string RazonSocial { get; set; }
        public string? Telefono { get; set; }
        public string? Direccion { get; set; }


        public Cliente() { }

        public Cliente(string nombre, string apellido, Email email, Password password, Rol rol, Rut rut, string razonSocial, string? telefono, string? direccion) : base(nombre, apellido, email, password, rol)
        {
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.Telefono = telefono;
            this.Direccion = direccion;

            Validar();
        }

        public override void Validar()
        {
            // Valida todo lo de Usuario
            base.Validar();

            // Valida lo propio de Cliente
            if (string.IsNullOrWhiteSpace(RazonSocial))
                throw new RazonSocialVaciaException();

            if (RazonSocial.Length < 2)
                throw new RazonSocialMinimaCaracteresException();

            if (RazonSocial.Length > 200)
                throw new RazonSocialExcesoCaracteresException();

            if (Telefono != null && Telefono.Length > 20)
                throw new ClienteTelefonoMasVeinteCaracteresException();

            if (Direccion != null && Direccion.Length > 300)
                throw new ClienteDireccionExcesoCaracteresException();
        }
    }
}
