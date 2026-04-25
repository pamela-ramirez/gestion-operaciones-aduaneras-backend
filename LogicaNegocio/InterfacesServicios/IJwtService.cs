using LogicaNegocio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio.InterfacesServicios
{
    public interface IJwtService
    {
        string GenerarToken(Usuario usuario);
    }
}
