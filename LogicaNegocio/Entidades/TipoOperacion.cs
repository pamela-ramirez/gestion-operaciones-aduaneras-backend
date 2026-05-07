using LogicaNegocio.Excepciones.TipoOperacion;
using LogicaNegocio.InterfacesEntidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.Entidades
{
    public class TipoOperacion : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoOperacion() { }
        public TipoOperacion(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void Validar()
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new DescripcionTipoOperacionVaciaException();
        }
    }
}
