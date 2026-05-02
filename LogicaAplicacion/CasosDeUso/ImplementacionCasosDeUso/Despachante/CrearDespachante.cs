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
    public class CrearDespachante : ICrearDespachante
    {
        private readonly IRepositorioDespachante _repositorioDespachante;
        private readonly IRepositorioRol _repositorioRol;
        public CrearDespachante(IRepositorioDespachante repositorioDespachante, IRepositorioRol repositorioRol)
        {
            _repositorioDespachante = repositorioDespachante;
            _repositorioRol = repositorioRol;
        }
        public CrearDespachanteRespuestaDTO Ejecutar(CrearDespachanteDTO dto)
        {
            /*
             *             var existe = _clienteRepo.ExisteRut(dto.Rut);
            if (existe)
                throw new Exception("Ya existe un cliente con ese RUT");

            var rolCliente = _rolRepo.FindById(3);

            var username = $"{dto.Email.Split('@')[0]}";
            var passwordTemporal = "Despacho100!";

            var cliente = ClienteMapper.ToEntity(dto, rolCliente);

            _clienteRepo.Add(cliente);

            return ClienteMapper.ToDTO(cliente, username, passwordTemporal);
             */

            var rolDespachante = _repositorioRol.FindById(2);
            var existe = _repositorioDespachante.ExisteEmail(dto.Email);
            if (existe)
                throw new Exception("Ya existe un despachante con ese email");

            var username = $"{dto.Email.Split('@')[0]}";
            var passwordTemporal = "Despacho100!";

        }
    }
}
