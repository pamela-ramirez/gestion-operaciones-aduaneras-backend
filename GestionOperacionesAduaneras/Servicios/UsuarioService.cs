using Compartido.DTOs.Usuarios;
using LogicaNegocio.Entidades;
using LogicaNegocio.Excepciones.Roles;
using LogicaNegocio.Excepciones.Usuarios;
using LogicaNegocio.Excepciones.Usuarios.Login;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using LogicaNegocio.ValueObject;

namespace GestionOperacionesAduaneras.Servicios
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IRepositorioUsuario _repositorioUsuario;
        private readonly IRepositorioRol _repositorioRol;

        public UsuarioService(IRepositorioUsuario repositorioUsuario, IRepositorioRol repositorioRol)
        {
            _repositorioUsuario = repositorioUsuario;
            _repositorioRol = repositorioRol;   
        }
        public void EliminarUsuario(int id)
        {
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            _repositorioUsuario.Delete(id);
        }

        public UsuarioRespuestaDTO ModificarUsuario(int id, ModificarUsuarioDTO dto)
        {
            // Verificar que el usuario exista en la base de datos
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            // Verificar que el nuevo email no esté en uso por otro usuario
            if (usuario.Email.Valor != dto.Email)
            {
                var emailEnUso = _repositorioUsuario.GetByEmail(dto.Email).Result;
                if (emailEnUso != null)
                    throw new UsuarioExistenteConMismoCorreoException();
            }

            // Verificar que se haya asignado un rol válido
            if (dto.RolId <= 0)
                throw new RolDebeSerAsignadoException();

            if(dto.RolId != usuario.RolId)
            {
                // Verificar que el rol existe en la base de datos
                var rol = _repositorioRol.FindById(dto.RolId);
                if (rol == null)
                     throw new RolNoEncontradoException();
            }

            // Actualizar datos
            usuario.Nombre = dto.Nombre;
            usuario.Apellido = dto.Apellido;
            usuario.Email = new Email(dto.Email);
            usuario.RolId = dto.RolId;

            usuario.Validar();
            _repositorioUsuario.Update(usuario, id);

            return MapearARespuesta(usuario);
        }

        public UsuarioRespuestaDTO ObtenerUsuarioPorId(int id)
        {
            var usuario = _repositorioUsuario.FindById(id);
            if (usuario == null)
                throw new UsuarioNoEncontradoException();

            return MapearARespuesta(usuario);
        }

        public IEnumerable<UsuarioRespuestaDTO> ObtenerUsuarios()
        {
            var usuarios = _repositorioUsuario.FindAll();
            return usuarios.Select(u => MapearARespuesta(u)).ToList();
        }

        // Método privado para convertir Usuario a UsuarioRespuestaDTO
        // Lo usamos en varios métodos para no repetir código, si se agregan campos al DTO
        // solo se cambia en un lugar
        private UsuarioRespuestaDTO MapearARespuesta(Usuario usuario)
        {
            return new UsuarioRespuestaDTO
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email.Valor,
                Rol = usuario.Rol?.NombreRol ?? "Sin rol"
            };
        }
    }
}

