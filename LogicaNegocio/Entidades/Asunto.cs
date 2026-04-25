using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class Asunto
    {
        public int Id { get; set; }
        public Nomenclatura Nomenclatura { get; set; }
        public string NombreCliente { get; set; }
        public int? NroDua { get; set; }
        public int? NroCarpeta { get; set; }

        public Asunto() { }
        public Asunto(Nomenclatura nomenclatura, string nombreCliente, int? nroDua, int? nroCarpeta)
        {
            Nomenclatura = nomenclatura;
            NombreCliente = nombreCliente;
            NroDua = nroDua;
            NroCarpeta = nroCarpeta;
        }

        public string GenerarAsunto()
        {
            return Nomenclatura switch
            {
                Nomenclatura.LiqAprox =>
                    $"LIQ APROX – {NombreCliente}",

                Nomenclatura.Liq =>
                    $"LIQ – {NombreCliente} – Carpeta {NroCarpeta} – DUA {NroDua}",

                Nomenclatura.DocumentacionYFacturacion =>
                    $"Documentación y facturas – {NombreCliente} – DUA {NroDua} – Carpeta {NroCarpeta}",

                _ => string.Empty
            };
        }
    }
}
