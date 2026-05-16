using LogicaNegocio.Excepciones.TipoConocimiento;
using LogicaNegocio.InterfacesEntidades;

namespace LogicaNegocio.Entidades
{
    public class TipoConocimiento : IEntity, IValidable
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public TipoConocimiento() { }
        public TipoConocimiento(string descripcion)
        {
            Descripcion = descripcion;
        }

        public void Validar() {
            if (string.IsNullOrWhiteSpace(Descripcion))
                throw new DescripcionTipoConocimientoVaciaException();
        }
    }
}
