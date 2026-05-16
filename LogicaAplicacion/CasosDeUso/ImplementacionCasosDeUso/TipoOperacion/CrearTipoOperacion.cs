using Compartido.DTOs.TipoOperacion;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.TipoOperacion;
using LogicaAplicacion.Excepciones.TipoOperacion;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.TipoOperacion
{
    public class CrearTipoOperacion : ICrearTipoOperacion
    {
        private readonly IRepositorioTipoOperacion _repoTipoOperacion;

        public CrearTipoOperacion(IRepositorioTipoOperacion repoTipoOperacion)
        {
            _repoTipoOperacion = repoTipoOperacion;
        }

        public TipoOperacionListadoDTO Ejecutar(CrearTipoOperacionDTO dto)
        {
            if (dto == null || string.IsNullOrWhiteSpace(dto.Descripcion))
                throw new DescripcionTipoOperacionVaciaException();

            // Verificar que no exista otro tipo con la misma descripción
            var existente = _repoTipoOperacion.FindByDescripcion(dto.Descripcion.Trim());
            if (existente != null)
                throw new DescripcionTipoOperacionYaExistenteException();

            // El mapper convierte el DTO a entidad
            var tipoOperacion = TipoOperacionMapper.ToEntity(dto);

            _repoTipoOperacion.Add(tipoOperacion);

            // Retornamos el DTO de respuesta con el ID asignado por la base de datos
            return TipoOperacionMapper.ToDTO(tipoOperacion);
        }
    }
}
