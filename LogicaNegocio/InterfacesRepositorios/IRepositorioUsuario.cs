using LogicaNegocio.Entidades;

namespace LogicaNegocio.InterfacesRepositorios
{
    public interface IRepositorioUsuario : IRepositorio<Usuario>
    {
        //Usuario Login(string email, string contrasenia);
        Task<Usuario?> GetByEmail(string email);
        //void UpdateEstado(Usuario item, int id);

        bool ExisteEmail(string email);
        void UpdatePassword(Usuario item, int id);
        void AceptarConsentimeinto(int id);
    }
}
