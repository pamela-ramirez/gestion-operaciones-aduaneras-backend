namespace Compartido.DTOs.Usuarios
{
    public class UsuarioLogueadoDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Estado { get; set; }
        public bool PrimerLogin { get; set; }
    }
}
