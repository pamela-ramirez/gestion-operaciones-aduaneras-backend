using LogicaNegocio.Excepciones.Documento;
using System.ComponentModel.DataAnnotations;

namespace LogicaNegocio.Entidades
{
    public class Documento
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string RutaArchivo { get; set; }
        public TipoFormato Formato { get; set; } // PDF, JPG, PNG
        public DateTime FechaCarga { get; set; } = DateTime.Now;

        public int OperacionId { get; set; }
        public Operacion Operacion { get; set; }

        public Documento() { }
        public Documento(string nombre, string rutaArchivo,
            TipoFormato formato, int operacionid)
        {
            Nombre = nombre;
            RutaArchivo = rutaArchivo;
            Formato = formato;
            OperacionId = operacionid;
            FechaCarga = DateTime.Now;

            Validar(); // Valida al final, cuando ya todo está asignado
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Nombre))
                throw new NombreDocumentoVacioException();
            if(string.IsNullOrEmpty(RutaArchivo))
                throw new RutaArchivoDocumentoVaciaException();
            if (!Enum.IsDefined(typeof(TipoFormato), Formato))
                throw new FormatoDocumentoInvalidoException();
            if(OperacionId <= 0)
                throw new OperacionIdInvalidoException();
        }
    }
}
