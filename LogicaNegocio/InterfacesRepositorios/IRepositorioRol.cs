using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Compartido.DTOs.Rol.RolDTO;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioRol:IRepositorio<Rol>
    {
        Rol FindByNombre(string nombreRol);

    }
}
