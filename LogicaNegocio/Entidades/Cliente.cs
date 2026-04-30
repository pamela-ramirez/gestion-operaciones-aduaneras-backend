using LogicaNegocio.Excepciones;
using LogicaNegocio.Excepciones.Cliente;
using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Cliente:Usuario
    {
        public Rut Rut { get; set; }
        public string Telefono { get; set; } = string.Empty;
        public string? Direccion { get; set; }


        public Cliente() { }

        public Cliente(string nombre, string apellido, Email email, Password password, Rol rol, Rut rut, string telefono, string? direccion) : base(nombre, apellido, email, password, rol)
        {
            this.Rut = rut;
            this.Telefono = telefono;
            this.Direccion = direccion;
            ValidarCliente();
        }

        public void ValidarCliente()
        {
            if (string.IsNullOrWhiteSpace(Telefono))
                throw new ClienteTelefonoVacioException();

            if (Telefono.Length > 20)
                throw new ClienteTelefonoMasVeinteCaracteresException();

            if (Direccion != null && Direccion.Length > 300)
                throw new ClienteDireccionExcesoCaracteresException();
        }

    }
}
