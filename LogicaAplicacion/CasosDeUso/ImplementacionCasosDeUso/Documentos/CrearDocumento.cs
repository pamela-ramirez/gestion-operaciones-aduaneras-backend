using Compartido.DTOs.Documento;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Documento;
using LogicaAplicacion.Excepciones.Documento;
using LogicaAplicacion.Excepciones.Operacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.Entidades;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Documentos
{
    public class CrearDocumento : ICrearDocumento
    {
        private readonly IRepositorioDocumento _repositorioDocumento;
        private readonly IRepositorioOperacion _repositorioOperacion;
        private readonly IAlmacenamientoArchivos _almacenamiento;
        public CrearDocumento(IRepositorioDocumento repositorioDocumento, 
            IRepositorioOperacion repositorioOperacion,
            IAlmacenamientoArchivos almacenamiento)
        {
            _repositorioDocumento = repositorioDocumento;
            _repositorioOperacion = repositorioOperacion;
            _almacenamiento = almacenamiento;
        }
        public async Task<DocumentoRespuestaDTO> Ejecutar(CrearDocumentoDTO dto)
        {
            var operacion = _repositorioOperacion.FindById(dto.OperacionId);
            if (operacion == null)
                throw new OperacionNoEncontradaException();

            // Detectar el formato del archivo
            string extensionConPunto = Path.GetExtension(dto.Archivo.FileName);
            string extension = extensionConPunto.Replace(".", "").ToUpper();

            var formatosPermitidos = new Dictionary<string, TipoFormato>
            {
                { "PDF", TipoFormato.PDF },
                { "JPG", TipoFormato.JPG },
                { "PNG", TipoFormato.PNG }
            };

            if (!formatosPermitidos.TryGetValue(extension, out var formato))
                throw new FormatoNoPermitidoException(extension);

            // Se usa para local, Firebase o Azure
            var rutaArchivo = await _almacenamiento.GuardarAsync(
                dto.Archivo.OpenReadStream(),
                dto.Archivo.FileName
            );

            var documento = new Documento(dto.Nombre, rutaArchivo, formato, dto.OperacionId);
            documento.OperacionId = dto.OperacionId;

            _repositorioDocumento.Add(documento);

            return DocumentoMapper.ToDTO(documento);
        }
    }
    
}
