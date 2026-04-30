using Compartido.DTOs.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaAplicacion.Mappers;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol
{
    public class ObtenerRoles : IObtenerRoles
    {
        public IRepositorioRol RepoRol { get; set; }
        public ObtenerRoles(IRepositorioRol repoRol)
        {
            RepoRol = repoRol;
        }

        public IEnumerable<RolListadoDTO> Ejecutar()
        {
            var roles = RepoRol.FindAll();
            return RolMapper.ListToDTO(roles);
        }
    }
}
