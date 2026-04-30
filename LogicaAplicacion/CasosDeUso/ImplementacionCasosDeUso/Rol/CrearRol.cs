using Compartido.DTOs.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Rol.RolDTO;

namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class CrearRol : ICrearRol
    {
        public IRepositorioRol RepoRol { get; set; }
        public CrearRol(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }
        public RolListadoDTO Ejecutar(RolDTO rolDTO)
        {
            var rol = RolMapper.DTORolToRol(rolDTO);

            RepoRol.Add(rol);

            return RolMapper.RolToDTO(rol);
        }

    }
}
