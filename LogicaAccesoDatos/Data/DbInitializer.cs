using LogicaAccesoDatos.Contexto;
using LogicaNegocio.Entidades;
using LogicaNegocio.ValueObject;

namespace LogicaAccesoDatos.Data
{
    public static class DbInitializer
    {
        public static void Inicializar(GestionOperacionesDbContext context)
        {
            // 1. Verificar si ya existe el admin
            if (context.Usuarios.Any(u => u.Email.Valor == "admin@admin.com"))
                return;

            // 2. Obtener rol administrador
            var rolAdmin = context.Roles.FirstOrDefault(r => r.NombreRol == "Administrador");

            if (rolAdmin == null)
                return; // seguridad

            // 3. Crear usuario admin
            var admin = new Despachante
            {
                Email = new Email("admin@admin.com"),
                Password = new Password("Admin123!!"),
                RolId = rolAdmin.Id
            };

            context.Usuarios.Add(admin);
            context.SaveChanges();
        }
    }
}