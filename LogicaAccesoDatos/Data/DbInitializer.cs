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
            var rolAdmin = context.Roles.FirstOrDefault(r => r.NombreRol == "Admin");

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

            // Verificar si ya hay operaciones cargadas (para no duplicar)
            if (context.Operaciones.Any())
                return;

            var cliente1 = context.Usuarios.OfType<Cliente>()
                .FirstOrDefault(c => c.Email.Valor == "martina.gonzalez@gonzalezimport.com");
            var cliente2 = context.Usuarios.OfType<Cliente>()
                .FirstOrDefault(c => c.Email.Valor == "roberto.alvarez@alvarezexport.com");
            var cliente3 = context.Usuarios.OfType<Cliente>()
                .FirstOrDefault(c => c.Email.Valor == "laura.mendez@mendezasociados.com");

            var tipoImportacion = context.TiposOperacion.FirstOrDefault(t => t.Descripcion == "Importación");
            var tipoExportacion = context.TiposOperacion.FirstOrDefault(t => t.Descripcion == "Exportación");

            if (cliente1 != null && cliente2 != null && cliente3 != null
                && tipoImportacion != null && tipoExportacion != null)
            {
                var operaciones = new List<Operacion>
    {
        new Operacion("CARP-2025-001", tipoImportacion, cliente1),
        new Operacion("CARP-2025-002", tipoExportacion, cliente2),
        new Operacion("CARP-2025-003", tipoImportacion, cliente3),
        new Operacion("CARP-2025-004", tipoExportacion, cliente1),
    };

                context.Operaciones.AddRange(operaciones);
                context.SaveChanges();
            }

        }
    }
}