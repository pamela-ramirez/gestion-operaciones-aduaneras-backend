using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Documento
{
    public class CrearDocumentoDTO
    {
        public string Nombre { get; set; }
        public IFormFile Archivo { get; set; }  // el archivo binario
        public int OperacionId { get; set; }
    }


    public class DocumentoRespuestaDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Formato { get; set; }   // "PDF", "JPG" o "PNG"
        public DateTime FechaCarga { get; set; }
        public int OperacionId { get; set; }
        public string RutaArchivo { get; set; }
    }

}
