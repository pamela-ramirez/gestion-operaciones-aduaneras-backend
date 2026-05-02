using Compartido.DTOs.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios
{
    public interface IModificarUsuario
    {
        UsuarioListadoDTO Ejecutar(int id, ModificarUsuarioDTO dto);
    }
}