using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAccesoDatos.Servicios
{
    public class AlmacenamientoLocal : IAlmacenamientoArchivos
    {
        public async Task<string> GuardarAsync(Stream archivo, string nombreArchivo)
        {
            var carpeta = Path.Combine("wwwroot", "documentos");
            Directory.CreateDirectory(carpeta);
            var nombre = $"{Guid.NewGuid()}_{nombreArchivo}";
            var ruta = Path.Combine(carpeta, nombre);

            using var stream = new FileStream(ruta, FileMode.Create);
            await archivo.CopyToAsync(stream);

            return ruta;
        }
    }
}
