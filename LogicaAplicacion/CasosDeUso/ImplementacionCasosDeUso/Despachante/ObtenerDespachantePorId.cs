using Compartido.DTOs.Despachante;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Despachante;
using LogicaNegocio.InterfacesRepositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                throw new Exception("Despachante no encontrado");
            }
            return new DespachanteDTO 
            {
                Nombre = despachante.Nombre,
                Apellido = despachante.Apellido,
                Email = despachante.Email.Valor,
                Codigo = despachante.Codigo
            };

            // TODO Pasar el new DespachanteDTO a un mapeador para mapearlo a un DTO
        }
    }
}
