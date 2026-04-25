using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Compartido.DTOs.Auth
{
    public class LoginResponseDTO
    {
        public string Token { get; set; }
        public string Rol { get; set; }
    }
}
