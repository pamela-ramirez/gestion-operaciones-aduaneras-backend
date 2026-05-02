using LogicaNegocio.ValueObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Despachante:Usuario
    {
        //codigo de despachante
        public string Codigo { get; set; } = string.Empty;


        public Despachante() { }

        public Despachante(string nombre, string apellido, Email email, Password password, Rol rol, string codigo) : base(nombre, apellido, email, password, rol)
        {
            this.Codigo = codigo;
        }


    }
}
