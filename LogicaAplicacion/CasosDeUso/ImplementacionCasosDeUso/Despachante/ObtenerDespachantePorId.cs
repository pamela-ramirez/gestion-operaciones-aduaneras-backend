using Compartido.DTOs.Despachante;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante;
using LogicaAplicacion.Excepciones.Usuario;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Despachante
{
    public class ObtenerDespachantePorId : IObtenerDespachantePorId
    {
        private readonly IRepositorioDespachante _repositorioDespachante;

        public ObtenerDespachantePorId(IRepositorioDespachante repositorioDespachante)
        {
            _repositorioDespachante = repositorioDespachante;
        }
        public DespachanteDTO Ejecutar(int id)
        {
            var despachante = _repositorioDespachante.FindById(id);
            if (despachante == null)
            {
                throw new UsuarioNoEncontradoException();
            }

            return DespachanteMapper.ToDespachanteDTO(despachante);

        }
    }
}
