using Compartido.DTOs.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface ILogin
    {
        Task<LoginResponseDTO> Ejecutar(LoginDTO dto);
    }
}
